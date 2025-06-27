using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Domain.Entities
{
    internal class Client
    {
        public  Guid ClientId { get; set; }
        public string Name { get; set; }

        public int Number { get; set; }
        public string  Email { get; set; }

        public string Address { get; set; }
    }
}
