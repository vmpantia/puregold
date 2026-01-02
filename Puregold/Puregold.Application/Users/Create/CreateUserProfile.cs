using AutoMapper;
using Puregold.Domain.Users;

namespace Puregold.Application.Users.Create;

public sealed class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}