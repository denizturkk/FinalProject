using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //asp.net(wep api) have to verify json web token
    //with which key and algorithm
    // looka at web api appsetings.json securit key
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
