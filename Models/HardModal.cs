using e_comm.Models.Parents;
using System.ComponentModel.DataAnnotations;

namespace e_comm.Models
{
    public class HardModal : HardWare
    {
        [Required]
        public int Storage { get; set; }
    }
}
