using Puregold.Domain.Enums;

namespace Puregold.Domain.Common.Responses;

public sealed record Error(ErrorType Type, string Message, object? Value = null);