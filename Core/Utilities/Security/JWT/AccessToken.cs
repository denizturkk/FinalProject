using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //JTO proporties
    public class AccessToken
    { 
        //token is striing propority
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
