using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Application.Commons.Results
{
    public class Result<T> 
    {

        public T? Data { get; }
        public IEnumerable<Error> Erros { get; } = Enumerable.Empty<Error>();

        public bool 
        //public bool IsSucess { get; }
        //public string Error { get; }


        //public bool IsFailure => !IsSucess;

        //protected  Result(bool isSuccess, string error)
        //{
        //    IsSucess = isSuccess;
        //    Error = error;
        //}

        //public static Result Success() =>  new Result(true, string.Empty);

        //public static Result Failure(string error) => new Result(false, error);


    }
}
