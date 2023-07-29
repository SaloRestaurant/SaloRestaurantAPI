using AutoMapper;
using SaloAPI.BusinessLogic.ApiCommands.Sessions;
using SaloAPI.BusinessLogic.ApiCommands.Users;

namespace SaloAPI.Presentation.Profiles;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        CreateMap<LoginRequest, LoginCommand>();
        CreateMap<ChangePasswordRequest, ChangePasswordCommand>();
        CreateMap<RegisterRequest, RegisterCommand>();
    }
}