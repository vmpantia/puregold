using AutoMapper;
using MediatR;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Common.Responses;
using Puregold.Domain.ItemCategories;

namespace Puregold.Application.ItemCategories.Create;

public sealed class CreateItemCategoryCommandHandler(IItemCategoryRepository itemCategoryRepository, IMapper mapper) : IRequestHandler<CreateItemCategoryCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
    {
        // Check if item name already exists
        if (await itemCategoryRepository.IsExistAsync(itmc => itmc.Name == request.ItemCategory.Name, cancellationToken))
            return ItemCategoryErrors.NameAlreadyExists(request.ItemCategory.Name);
        
        var itemCategory = mapper.Map<ItemCategory>(request.ItemCategory);
        var result = await itemCategoryRepository.CreateAsync(itemCategory, cancellationToken);
        return result.Id;
    }
}