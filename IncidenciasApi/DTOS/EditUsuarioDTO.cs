using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class EditUsuarioDTO
    {
         public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}