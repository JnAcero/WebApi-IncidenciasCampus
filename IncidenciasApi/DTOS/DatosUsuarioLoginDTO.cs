using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class DatosUsuarioLoginDTO : IRespuestaDTO
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object result   { get; set; }
        public string token { get; set; }
    }
}