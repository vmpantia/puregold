using Puregold.Domain.Common.Responses;
using Puregold.Domain.Enums;

namespace Puregold.Domain.Items;

public sealed class ItemErrors
{
    public static Error ItemNameAlreadyExists(string itemName) => new(ErrorType.Invalid, $"Item with name {itemName} already exists in the database.");
    public static Error ItemCategoryNotFound(string categoryName) =>  new(ErrorType.NotFound, $"Item category with name {categoryName} is not found in the database.");
}