using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.RegisterFeatures;
using CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetById;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
{
    public class AutoMapperProfilling : Profile
    {
        public AutoMapperProfilling()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UpdateUserResponse>();

            CreateMap<GetAllUserRequest, User>();
            CreateMap<User, GetAllUserResponse>();            
            
            CreateMap<GetByIdUserRequest, User>();
            CreateMap<User, GetByIdUserResponse>();

            CreateMap<RegisterRequest, User>();
            CreateMap<User, RegisterResponse>();

            CreateMap<LoginRequest, User>();
            CreateMap<User, LoginResponse>();
        }
    }
}
