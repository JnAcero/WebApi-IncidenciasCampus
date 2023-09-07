using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class TelefonoTrainerCreationDTO
    {
        public int TrainerId { get; set; }
         public int TipoTelefonoId { get; set; }
         public string NumeroTelefono { get; set; }=null!;
        
    }
}