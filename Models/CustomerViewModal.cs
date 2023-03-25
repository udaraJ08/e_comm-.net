using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace e_comm.Models
{
    public class CustomerViewModal
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }       
        [Required]
        public string Nic { get; set;  }
        public DateTime Dob { get; set; }
    }
}
