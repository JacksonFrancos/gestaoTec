using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commo.Commons.Results
{
    public class Result<T> 
    {

        public T? Data { get; }
        public IEnumerable<Error> Erros { get; } = Enumerable.Empty<Error>();
        public bool Valid => !Erros.Any();


        // esse construc é usado somente para quando tiver "dados"
        internal Result(T data)
        {
            Data = data;
        }


        // esse construc é usado  para quando tiver  "dados" e "erros"
        internal Result (T data, IEnumerable<Error> erros)
        {
            Data = data;
            Erros = erros;
        }

        // somente para listar os erros
        internal Result(IEnumerable<Error> erros)
        {
            Erros = erros;
        }


        // usado para declarar novos erros, quando eu n tiver o erro listado
        internal Result(Error erro)
        {
            Erros = new[] { erro };
        }

    }

    public sealed class Result
    {

        public IEnumerable<Error> Errors { get; } = Enumerable.Empty<Error>();

        public bool Valid => Errors == null || !Errors.Any();

        internal Result()
        {
        }
        internal Result(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result Fail(Error error)
        {
            return new Result(new[] { error });
        }

    }
}
