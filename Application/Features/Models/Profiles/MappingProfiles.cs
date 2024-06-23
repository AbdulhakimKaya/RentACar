using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetById.GetById;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Application.Features.Models.Queries.GetListNoPaginate;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreatedModelResponse>().ReverseMap();
        
        CreateMap<Model, UpdateModelCommand>().ReverseMap();
        CreateMap<Model, UpdatedModelResponse>().ReverseMap();
        
        CreateMap<Model, DeleteModelCommand>().ReverseMap();
        CreateMap<Model, DeletedModelResponse>().ReverseMap();
        
        CreateMap<Model, GetListModelListItemDto>()
            .ForMember(destinationMember: m => m.BrandName, memberOptions: opt => opt.MapFrom(m => m.Brand!.Name))
            .ForMember(destinationMember: m => m.FuelName, memberOptions: opt => opt.MapFrom(m => m.Fuel!.Name))
            //.ForMember(destinationMember: m => m.ColorName, memberOptions: opt => opt.MapFrom(m => m.Color!.Name))
            .ForMember(destinationMember: m => m.TransmissionName, memberOptions: opt => opt.MapFrom(m => m.Transmission!.Name))
            .ReverseMap();
        
        CreateMap<Model, GetListByDynamicModelListItem>()
            .ForMember(destinationMember: m => m.BrandName, memberOptions: opt => opt.MapFrom(m => m.Brand!.Name))
            .ForMember(destinationMember: m => m.FuelName, memberOptions: opt => opt.MapFrom(m => m.Fuel!.Name))
            //.ForMember(destinationMember: m => m.ColorName, memberOptions: opt => opt.MapFrom(m => m.Color!.Name))
            .ForMember(destinationMember: m => m.TransmissionName, memberOptions: opt => opt.MapFrom(m => m.Transmission!.Name))
            .ReverseMap();

        CreateMap<Model, GetListNoPaginateModelListItemDto>().ReverseMap();

        CreateMap<Model, GetByIdModelResponse>()
            .ForMember(m => m.BrandId, opt => opt.MapFrom(x => x.Brand!.Id))
            .ForMember(m => m.FuelId, opt => opt.MapFrom(x => x.Fuel!.Id))
            .ForMember(m => m.TransmissionId, opt => opt.MapFrom(x => x.Transmission!.Id))
            .ReverseMap();
        
        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItem>>().ReverseMap();
    }
}