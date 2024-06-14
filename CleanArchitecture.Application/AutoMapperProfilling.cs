using AutoMapper;
using AutoMapper.EquivalencyExpression;
using CleanArchitecture.Application.Features.UserFeatures.Command.Create;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
{
    public class AutoMapperProfilling : Profile
    {
        public AutoMapperProfilling()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();

            CreateMap<GetAllUserRequest, User>();
            CreateMap<User, GetAllUserResponse>();
        }
    }
}
