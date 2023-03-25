using e_comm.Models.Parents;
using System.ComponentModel.DataAnnotations;

namespace e_comm.Models
{
    public class RamModal : HardWare
    {
        [Required]
        public int Size { get; set; }
    }
}
