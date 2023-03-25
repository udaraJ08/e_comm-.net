using System.ComponentModel.DataAnnotations;

namespace e_comm.Models.Parents
{
    public class HardWare
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required]
        public string  Title{ get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
