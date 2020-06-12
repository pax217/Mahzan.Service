using Mahzan.Business.Events.Users;
using Mahzan.Business.Exceptions.Users.Login;
using Mahzan.Business.Results.Users;
using Mahzan.DataAccess.DTO.Users;
using Mahzan.DataAccess.Repositories.Users.Login;
using Mahzan.Models.Enums.Result;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Users.Login
{
    public class LoginEventHandler : ILoginEventHandler
    {
        private readonly ILoginRepository _loginRepository;

        public IConfiguration _config
        {
            get
            {
                return new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
            }
        }

        public LoginEventHandler(
            ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginResult> HandleEvent(LoginEvent loginEvent)
        {
            LoginResult result = new LoginResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = $"Inicio de Sesión",
                Message = $"El usuario {loginEvent.UserName} inició sesión correctamente."
            };

            //Busca si el usuario existe


            await _loginRepository
                .HandleRepository(new LoginDto
                {
                    UserName = loginEvent.UserName,
                    Password = loginEvent.Password
                });


            result.Token = await GetToken(loginEvent);

            return result;
        }

        private async Task<string> GetToken(LoginEvent loginEvent)
        {

            string result = string.Empty;

            Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, loginEvent.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }
    }
}
