

namespace IncidenciasApi.DTOS
{
    public class TrainerCreationDTO
    {
        public string NumDocumento { get; set; } =null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Genero {get; set;} = null!;
        public DateTime FechaNacimineto { get; set; }
        public int CiudadId { get; set; } 
        
    }
}