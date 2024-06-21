using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Application.Helper.Interface;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Application.Helper
{
    public class RefreshTokenHelper : IRefreshTokenHelper
    {
        private readonly TokenManagement _token;
        private readonly IHttpContextAccessor _httpCont;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public RefreshTokenHelper(IOptions<TokenManagement> token, IHttpContextAccessor httpCont, IUserRepository userRepository, IMapper mapper)
        {
            _token = token.Value;
            _httpCont = httpCont;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string GenerateRefreshToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token.Secret));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
            };

            var tokenDescriptor = new JwtSecurityToken
                (
                    _token.Issuer,
                    _token.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_token.ExpiryRefreshMinutes),
                    signingCredentials: credential
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenDescriptor);
            return token;
        }

        public async void SetRefreshToken(string newRefreshToken, string username)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(_token.ExpiryRefreshMinutes)
            };
            _httpCont.HttpContext.Response.Cookies.Append("refreshToken", newRefreshToken, cookieOptions);

            var newUser = await _userRepository.GetByUsername(username);

            newUser.refresh_token = newRefreshToken;
            newUser.refresh_token_created = DateTime.UtcNow;
            newUser.refresh_token_expires = DateTime.UtcNow.AddMinutes(_token.ExpiryRefreshMinutes);

            _userRepository.Update(newUser);
        }
    }
}
