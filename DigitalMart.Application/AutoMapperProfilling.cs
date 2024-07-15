using AutoMapper;
using DigitalMart.Application.Features.AuthFeatures.LoginFeatures;
using DigitalMart.Application.Features.AuthFeatures.RegisterFeatures;
using DigitalMart.Application.Features.ProductFeatures.Command.CreateProduct;
using DigitalMart.Application.Features.UserFeatures.Command.UpdateUser;
using DigitalMart.Application.Features.UserFeatures.Query.GetAll;
using DigitalMart.Application.Features.UserFeatures.Query.GetByCategory;
using DigitalMart.Application.Features.UserFeatures.Query.GetById;
using DigitalMart.Application.Features.UserFeatures.Query.GetByUsername;
using DigitalMart.Domain.Entities;

namespace DigitalMart.Application
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
            
            CreateMap<GetByUsernameRequest, User>();
            CreateMap<User, GetByUsernameResponse>();

            CreateMap<RegisterRequest, User>();
            CreateMap<User, RegisterResponse>();

            CreateMap<LoginRequest, User>();
            CreateMap<User, LoginResponse>();
            
            CreateMap<GetAllProductRequest, Product>();
            CreateMap<Product, GetAllProductResponse>();            

            
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreateProductResponse>();
        }
    }
}
