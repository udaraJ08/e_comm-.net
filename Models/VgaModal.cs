using System.ComponentModel.DataAnnotations;
using e_comm.Models.Parents;

namespace e_comm.Models
{
    public class VgaModal : HardWare
    {
        [Required]
        public int Size { get; set; }
    }
}
