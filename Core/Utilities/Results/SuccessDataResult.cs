using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //success verison
    public class SuccessDataResult<T> :DataResult<T>
    {
        //all infos
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }

        //without message
        public SuccessDataResult(T data):base(data,true)
        {

        }

        //return data as default : rare
        //calıstıgım T nin default'u
        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        //rare
        public SuccessDataResult():base(default,true)
        {

        }


    }
}
