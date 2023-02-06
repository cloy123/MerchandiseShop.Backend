using AutoMapper;
using MerchandiseShop.Application.Users.Commands.FindUser;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.User;
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

        public AuthController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
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
                var issuer = _configuration["Jwt:Issuer"];
                var audience = "";
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", findUserVm.UserDto.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, findUserVm.UserDto.Email),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name)
                    }),
                    Issuer = issuer,
                    Audience = audience,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                findUserVm.Token = jwtToken;
            }
            return Ok(findUserVm);
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            return NotFound();
        }
    }
}