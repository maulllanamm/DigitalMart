using CleanArchitecture.Application.Features.AuthFeatures.RegisterFeatures;
using CleanArchitecture.Application.Helper.Interface;
using CleanArchitecture.WebAPI.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;

namespace CleanArchitecture.WebAPIUnitTest
{
    public class AuthControllerTest
    {
        private readonly AuthController _controller;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IAccessTokenHelper> _accessTokenHelperMock;
        private readonly Mock<IRefreshTokenHelper> _refreshTokenHelperMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;

        public AuthControllerTest()
        {
            // Setup mocks
            _mediatorMock = new Mock<IMediator>();
            _accessTokenHelperMock = new Mock<IAccessTokenHelper>();
            _refreshTokenHelperMock = new Mock<IRefreshTokenHelper>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            // Initialize controller with mocks
            _controller = new AuthController(
                _mediatorMock.Object,
                _accessTokenHelperMock.Object,
                _refreshTokenHelperMock.Object,
                _httpContextAccessorMock.Object
            );
        }


        [Fact]
        public async Task Register_SuccessfulRegister_ReturnsOk()
        {
            // Arrange
            var registerRequest = new RegisterRequest(
                Username: "testusername",
                Password: "testpassword",
                Email: "testemail@gmail.com",
                Fullname: "test user",
                PhoneNumber: "1234567890",
                Address: "test address"
            );

            var cancellationToken = CancellationToken.None;
            var expectedResult = new RegisterResponse // Mock expected response
            {
                Username = registerRequest.Username,
                Email = registerRequest.Email,
                FullName = registerRequest.Fullname,
                PhoneNumber = registerRequest.PhoneNumber,
                Address = registerRequest.Address
            };   

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<RegisterRequest>(), cancellationToken))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.Register(registerRequest, cancellationToken);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            var registerResponse = okResult.Value as RegisterResponse;
            Assert.NotNull(registerResponse);
            Assert.Equal(expectedResult.Username, registerResponse.Username);
            Assert.Equal(expectedResult.Email, registerResponse.Email);
            Assert.Equal(expectedResult.FullName, registerResponse.FullName);
            Assert.Equal(expectedResult.PhoneNumber, registerResponse.PhoneNumber);
            Assert.Equal(expectedResult.Address, registerResponse.Address);
        }
    }
}