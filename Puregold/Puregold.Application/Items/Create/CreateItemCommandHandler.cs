using AutoMapper;
using MediatR;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Common.Responses;
using Puregold.Domain.ItemCategories;
using Puregold.Domain.Items;

namespace Puregold.Application.Items.Create;

public sealed class CreateItemCommandHandler(IItemRepository itemRepository, IItemCategoryRepository itemCategoryRepository, IMapper mapper) : IRequestHandler<CreateItemCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        // Check if item name already exists
        if (await itemRepository.IsExistAsync(itm => itm.Name == request.Item.Name, cancellationToken))
            return ItemErrors.NameAlreadyExists(request.Item.Name);
        
        // Check if item category is not existing
        if (!await itemCategoryRepository.IsExistAsync(itmc => itmc.Id == request.Item.CategoryId && itmc.Name == request.Item.CategoryName, cancellationToken))
            return ItemCategoryErrors.NotFound(request.Item.CategoryName);
        
        var item = mapper.Map<Item>(request.Item);
        var result = await itemRepository.CreateAsync(item, cancellationToken);
        return result.Id;
    }
}