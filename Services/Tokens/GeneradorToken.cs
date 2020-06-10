using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RappiApi.Models;
using RappiApi.Models.ViewModels;
using RappiApi.Services.Interfaces;

namespace RappiApi.Services.Tokens
{
    public class GeneradorToken : IGeneradorToken
    {

        private readonly IConfiguration _config;
        public GeneradorToken(IConfiguration config)
        {
            _config = config;
        }

        public JsonResult GenerarToken(LoginViewModel login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            UsuarioAplicacion user = new UsuarioAplicacion
            {
                UserName = login.NombreUsuario
            };


            SymmetricSecurityKey claveSeguridad = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(
              _config["JwtOptions:ClaveSecreta"]));

            SigningCredentials credenciales = new SigningCredentials(claveSeguridad, SecurityAlgorithms.HmacSha256);
            List<Claim> listClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("name", ""),
                new Claim("id", ""),
                new Claim("cualquiercosavalida", "ejemploheaderparavalidar")
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: listClaims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credenciales);

            string json_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { token = json_token });
        }
    }
}