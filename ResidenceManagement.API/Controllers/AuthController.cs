using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ResidenceManagement.Application.Features.Commands.Authentications.DeleteUser;
using ResidenceManagement.Application.Features.Commands.Authentications.SignUpUser;
using ResidenceManagement.Application.Features.Commands.Authentications.UpdateUser;
using ResidenceManagement.Application.Features.Queries.Authentications.GetUsers;
using ResidenceManagement.Application.Features.Queries.Authentications.SignInUser;
using ResidenceManagement.Application.Models.Users;
using ResidenceManagement.Application.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtSettings _jwtSettings;

        public AuthController(IMediator mediator,
            IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _jwtSettings = jwtSettings.Value;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpUserCommand signUpUserCommand)
        {
            var result = await _mediator.Send(signUpUserCommand);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInUserQuery signInUserCommandQuery)
        {
            var query = signInUserCommandQuery;
            var userModel = await _mediator.Send(query);

            if (userModel != null)
            {
                var createdJwt = GenerateJwt(userModel);
                return Ok(createdJwt);
            }

            return BadRequest("Email or password incorrect.");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("users")]

        public ActionResult Get()
        {
            return Ok(_mediator.Send(new GetUserListQuery()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            return Ok(_mediator.Send(new DeleteUserCommand(id)));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IdentityResult> Update([FromBody] UpdateUserCommand userCommand)
        {
            
            return await _mediator.Send(userCommand);
        }

        private string GenerateJwt(UserModel userModel)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, userModel.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                    new Claim("UserRole",userModel.Roles.FirstOrDefault()?.ToString())
                };

            var roleClaims = userModel.Roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
