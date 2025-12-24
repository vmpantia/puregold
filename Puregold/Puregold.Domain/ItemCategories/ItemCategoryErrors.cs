using Puregold.Domain.Common.Responses;
using Puregold.Domain.Enums;

namespace Puregold.Domain.ItemCategories;

public abstract class ItemCategoryErrors
{
    public static Error NotFound(string name) =>  new(ErrorType.NotFound, $"Item category with name {name} is not found in the database.");
    public static Error NameAlreadyExists(string name) => new(ErrorType.Invalid, $"Item category with name {name} already exists in the database.");
}