using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commo.Commons.Results
{ 
    public class Error
    {
        public string Code { get; init; }

        public string Description { get; init; }

        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
        public  Error() { }

        public Error(string code, string description, string message)
        {
            Code = code;
            Description = description;
        }
    }
}
