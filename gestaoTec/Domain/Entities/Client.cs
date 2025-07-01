using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        // conceito de Invariantes 
        // esse metodo é chamado de Factory Method 
        public static Client Create ( String name , string email, string address , Guid clientID)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome não pode ser nullo", nameof(name));
            }
            return new Client
            {
                ClientId = clientID,
                Name = name,
                Email = email,
                Address = address,
                Number = 0
            };

        }
        public void Update(string name, string email, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome não pode ser nullo", nameof(name));
            }
            Name = name;
            Email = email;
            Address = address;
        }

    }


    

}
