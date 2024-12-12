using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Jwt_Core_Kamp.Dal
{
    public class BuildToken
    {
        public string CrateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreprojekampi");//startupta anahtar olarak yazdığımız 
            SymmetricSecurityKey key=new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //credentials->kimlik bilgileri
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //handler->işleyici oluşturan
            return handler.WriteToken(token);
        }
    }
}
