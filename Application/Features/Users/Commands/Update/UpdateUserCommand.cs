using System.Data;
using Application.Features.Auth.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.UserServices;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Users.Commands.Update;

public class UpdateUserCommand : IRequest<UpdateUserResponseDto>
{

    public int Id { get; set; }
    public UpdateUserDto UpdateUserDto { get; set; }
    
    
 public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
    {
        private readonly IDbConnection _dbConnection;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IConfiguration configuration, UserBusinessRules userBusinessRules, AuthBusinessRules authBusinessRules, IMapper mapper)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("RentACar"));
            _userBusinessRules = userBusinessRules;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserIdShouldNotBeExistsWhenSelected(request.Id);

            var query = "SELECT * FROM Users WHERE Id = @Id";
            var user = await _dbConnection.QueryFirstOrDefaultAsync<User>(query, new { Id = request.Id });

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");
            }

            await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UpdateUserDto.OldPassword);

            HashingHelper.CreatePasswordHash(
                request.UpdateUserDto.NewPassword,
                out byte[] passwordHash,
                out byte[] passwordSalt
            );

            var updateQuery = @"
                UPDATE Users
                SET Email = @Email,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    PasswordHash = @PasswordHash,
                    PasswordSalt = @PasswordSalt,
                    Status = @Status
                WHERE Id = @Id
            "; 

            var parameters = new
            {
                Email = request.UpdateUserDto.Email,
                FirstName = request.UpdateUserDto.FirstName,
                LastName = request.UpdateUserDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                Id = request.Id
            };

            await _dbConnection.ExecuteAsync(updateQuery, parameters);

            var updatedUserQuery = "SELECT * FROM Users WHERE Id = @Id";
            var updatedUser = await _dbConnection.QueryFirstOrDefaultAsync<User>(updatedUserQuery, new { Id = request.Id });

            var response = _mapper.Map<UpdateUserResponseDto>(updatedUser);

            return response;
        }
    }
    
    
}