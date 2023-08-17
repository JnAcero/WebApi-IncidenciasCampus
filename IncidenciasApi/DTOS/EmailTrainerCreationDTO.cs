using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidenciasApi.DTOS
{
    public class EmailTrainerCreationDTO
    {
        public int TrainerId { get; set; }
         public int TipoEmailId { get; set; }
         public string Email { get; set; }=null!;
    }
}