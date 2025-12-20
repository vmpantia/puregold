using AutoMapper;
using Puregold.Domain.Items;

namespace Puregold.Application.Items.Create;

public sealed class CreateItemProfile : Profile
{
    public CreateItemProfile()
    {
        CreateMap<CreateItemDto, Item>()
            .ForMember(src => src.ItemCategoryId, opt => opt.MapFrom(src => src.CategoryId));
    }
}