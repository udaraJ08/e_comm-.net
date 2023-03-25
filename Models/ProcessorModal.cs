using e_comm.Models.Parents;
using System.ComponentModel.DataAnnotations;

namespace e_comm.Models
{
    public class ProcessorModal : HardWare
    {
        [Required]
        public string Clock_speed { get; set; }
    }
}
