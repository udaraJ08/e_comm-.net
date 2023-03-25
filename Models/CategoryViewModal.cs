using System.ComponentModel.DataAnnotations;

namespace e_comm.Models
{
    public class CategoryViewModal
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int DeviceId { get; set; }
        [Required]
        public string DeviceTitle { get; set; }
        [Required]
        public string DeviceDescription { get; set; }
        [Required]
        public decimal Device_base_price { get; set; }
        [Required]
        public string Device_img { get; set; }
        [Required]
        public int Vga_id { get; set; }
        [Required]
        public string Vga_title { get; set; }
        [Required]
        public decimal Vga_price { get; set; }
        [Required]
        public int Vga_size { get; set; }
        [Required]
        public int Ram_id{ get; set; }
        [Required]
        public string Ram_title { get; set; }
        [Required]
        public decimal Ram_price { get; set; }
        [Required]
        public int Ram_size { get; set; }
        [Required]
        public int Processor_id { get; set; }
        [Required]
        public string Processor_title { get; set; }
        [Required]
        public decimal Processor_price { get; set; }
        [Required]
        public string Processor_clock_speed { get; set; }
        [Required]
        public int Hard_id { get; set; }
        [Required]
        public string Hard_title { get; set; }
        [Required]
        public decimal Hard_price { get; set; }
        [Required]
        public int Hard_storage { get; set; }
        [Required]
        public int Category_id { get; set; }
        [Required]
        public string Category_title{ get; set; }
        [Required]
        public decimal Specification_price { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
