using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Application.Models
{
    public  record Client (string Name , string Address , string Email, int Number , Guid ClientId);

    public record SaveClient (
        Guid ClientId,
        [Required] string Name,
        [Required] string Address,
        [Required, EmailAddress] string Email,
        int Number = 0);

    
}
