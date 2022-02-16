using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //all infos
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //without message
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //return data as default : rare
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //rare
        public ErrorDataResult() : base(default, false)
        {

        }


    }
}
