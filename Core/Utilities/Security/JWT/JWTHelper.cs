using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Extentions;
using System.Linq;

namespace Core.Utilities.Security.JWT
{
    

    public class JwtHelper : ITokenHelper
    {
        //Configuration-->>this is for reading appsetings.json file which is
        //subfile of WebApi and this Configuration class coming from .netcore
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        
        //Configuration: from .netcore
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //appsetings(configuration aslında appsetings.json bir örnek)
            //TokenOptions section'ını çekip programdaki TokenOptions classındaki
            //proporties e  atar(mapping)
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
           

        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //when token will expire--süresi ne saman bitecek(_tokenOptions configartiondan gelir)
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
           
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //which algorithm to use(inside SigningCredentialsHelper)
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
