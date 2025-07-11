using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Domain.Entities
{
    public class Client
    {
        public  Guid ClientId { get; set; }
        public  required string Name { get; set; }

        public int Number { get; set; }
        public required string  Email { get; set; }

        public required  string Address { get; set; }

        #region Properties navigation
        public ICollection<Equipment>? Equipments { get; set; } = new List<Equipment>();

        public ICollection<ServiceOrder>? ServiceOrders { get; set; } = new List<ServiceOrder>();
        #endregion Properties navigation

        
        // esse metodo é chamado de Factory Method 
        public static Client Create ( String name , string email, string address , Guid clientID)
        {
            // conceito de Invariantes : garatir que o objeto sempre estará em um estado válido
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
