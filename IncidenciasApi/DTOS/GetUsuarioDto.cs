using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class GetUsuarioDto
    {
        public string NombreUsuario { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public List<UsuarioRolDTO> UsuariosRoles { get; set; } = new List<UsuarioRolDTO>();
    }
}