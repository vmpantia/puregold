using Puregold.Domain.Common.Responses;
using Puregold.Domain.Enums;

namespace Puregold.Domain.Items;

public abstract class ItemErrors
{
    public static Error NameAlreadyExists(string name) => new(ErrorType.Invalid, $"Item with name {name} already exists in the database.");
}