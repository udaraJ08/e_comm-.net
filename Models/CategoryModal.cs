using System.ComponentModel.DataAnnotations;

namespace e_comm.Models
{
    public class CategoryModal
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
