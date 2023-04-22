using AutoMapper;
using MerchandiseShop.Application.UserRefreshTokens.Commands.CreateUserRefreshToken;
using MerchandiseShop.Application.UserRefreshTokens.Commands.DeleteUserRefreshToken;
using MerchandiseShop.Application.UserRefreshTokens.Queries.GetUserRefreshTokenList;
using MerchandiseShop.Application.Users.Commands.FindUser;
using MerchandiseShop.Application.Users.Queries.GetUserDetails;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.Users;
using MerchandiseShop.WebApi.AuthCommon;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MerchandiseShop.WebApi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IJWTManagerRepository _jWTManager;

        public AuthController(IMapper mapper, IConfiguration configuration, IJWTManagerRepository jWTManagerRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _jWTManager = jWTManagerRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var command = _mapper.Map<FindUserCommand>(loginDto);
            var findUserVm = await Mediator.Send(command);
            if (findUserVm.IsUserFound && findUserVm.IsPasswordCorrect && findUserVm.UserDto != null && findUserVm.IsAccess)
            {
                var role = Enumeration.GetAll<UserType>().FirstOrDefault(it => it.Id.Equals(findUserVm.UserDto.UserTypeId));
                if (role == null)
                {
                    throw new Exception();
                }
                var tokenData = new TokenData { 
                    UserId = findUserVm.UserDto.Id, 
                    Email = findUserVm.UserDto.Email, 
                    RoleName = role.Name };
                var tokens = _jWTManager.GenerateToken(tokenData);
                findUserVm.Token = tokens.AccessToken;
                findUserVm.RefreshToken = tokens.RefreshToken;
                var commandCreaterefreshToken = new CreateUserRefreshTokenCommand 
                { 
                    RefreshToken = findUserVm.RefreshToken, 
                    UserId = findUserVm.UserDto.Id 
                };
                await Mediator.Send(commandCreaterefreshToken);
            }
            return Ok(findUserVm);
        }

        [HttpPost]
        public async Task<ActionResult> RefreshToken([FromBody] Tokens tokens)
        {
            var tokenData = _jWTManager.GetPrincipalFromExpiredToken(tokens.AccessToken);
            var queryFindTokens = new GetUserRefreshTokenListQuery { UserId = tokenData.UserId };
            var refreshTokenList = await Mediator.Send(queryFindTokens);
            if (refreshTokenList.UserRefreshTokens.Count == 0)
            {
                return Unauthorized();
            }
            var refreshToken = refreshTokenList.UserRefreshTokens.FirstOrDefault(r => r.RefreshToken == tokens.RefreshToken);
            if (refreshToken == null)
            {
                return Unauthorized();
            }
            var queryGetUserDetails = new GetUserDetailsQuery { Id = tokenData.UserId };
            var userDetails = await Mediator.Send(queryGetUserDetails);
            var role = Enumeration.GetAll<UserType>().FirstOrDefault(it => it.Id.Equals(userDetails.UserTypeId));
            if (role == null)
            {
                throw new Exception();
            }

            var commandDeleteRefreshToken = new DeleteUserRefreshTokenCommand 
            { 
                Id = refreshToken.Id 
            };
            await Mediator.Send(commandDeleteRefreshToken);

            var newTokens = _jWTManager.GenerateToken(
                new TokenData
                {
                    UserId = userDetails.Id,
                    Email = userDetails.Email,
                    RoleName = role.Name
                });

            var commandCreateRefreshToken = 
                new CreateUserRefreshTokenCommand() 
                { 
                    RefreshToken = newTokens.RefreshToken, 
                    UserId = userDetails.Id 
                };
            await Mediator.Send(commandCreateRefreshToken);
            return Ok(newTokens);
        }

        [HttpPost]
        public async Task<ActionResult> Logout([FromBody] Tokens tokens)
        {
            var tokenData = _jWTManager.GetPrincipalFromExpiredToken(tokens.AccessToken);
            var queryFindTokens = new GetUserRefreshTokenListQuery { UserId = tokenData.UserId };
            var refreshTokenList = await Mediator.Send(queryFindTokens);
            if (refreshTokenList.UserRefreshTokens.Count == 0)
            {
                return Unauthorized();
            }
            var refreshToken = refreshTokenList.UserRefreshTokens.FirstOrDefault(r => r.RefreshToken == tokens.RefreshToken);
            if (refreshToken == null)
            {
                return Unauthorized();
            }
            var command = new DeleteUserRefreshTokenCommand { Id = refreshToken.Id };
            return Ok();
        }
    }
}