using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //base'e success ve message ı gönderir(resulttaki kodu tekrar yazmamızı saglar)
        //Data resultun farkı:Result voidler icin
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }

        public DataResult(T data,bool success): base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
