using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //w parameter
        public SuccessResult(string message):base(true,message)
        {

        }
        
        //no parameter
        public SuccessResult():base(true)
        {

        }
    }
}
