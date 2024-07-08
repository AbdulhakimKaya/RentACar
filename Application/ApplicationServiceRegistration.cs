using System.Data;
using System.Net;
using System.Reflection;
using Application.Services.AuthServices;
using Application.Services.FileServices;
using Application.Services.UserServices;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.SeriLog;
using Core.CrossCuttingConcerns.SeriLog.Loggers;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddTransient<IDbConnection>(provider => new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IFileService, FileService>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));

            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));

            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        // services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<LoggerServiceBase, MsSqlLogger>();
        
        return services;
    }
    
    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}