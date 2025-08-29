using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commo.DTOs
{
    public record ClientDTO(
      string Name,
      string Address,
      string Email,
      int Number,
      Guid ClientId
  );
}
