

namespace IncidenciasApi.DTOS
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TrainerId { get; set; } 
        public int RolId { get; set;}      
        
    }
}