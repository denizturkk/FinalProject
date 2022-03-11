using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //we use JWT for security but if we want to write a test unit
    //or use another method for security, its good to use interface
    //so we did
    public interface ITokenHelper
    {
        //user: for who program generates the token
        //List<OperationClaim>:which claims this user will have
        
        //user want to login with ıd and password .If these fields are correct then 
        //this method get the user who is just logined as a parameter then check this
        //users claims on database apart from that this method generates the jwt to
        //send this user.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
       
    }

}
