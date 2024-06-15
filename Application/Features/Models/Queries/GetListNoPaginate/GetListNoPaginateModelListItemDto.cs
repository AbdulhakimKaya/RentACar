namespace Application.Features.Models.Queries.GetListNoPaginate;

public sealed record GetListNoPaginateModelListItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string BrandName { get; init; }
    public string FuelName { get; init; }
    public string TransmissionName { get; init; }
}