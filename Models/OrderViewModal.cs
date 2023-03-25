using e_comm.Models.Parents;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace e_comm.Models
{
    public class OrderViewModal : OrderParent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Devices_title { get; set; }

        [Required]
        public string Customer_name { get; set; }

        [Required]
        public string Ram_title { get; set; }

        [Required]
        public string Vga_title { get; set; }

        [Required]
        public string Hard_title { get; set; }

        [Required]  
        public string Processor_title { get; set; }
        [Required]
        public int Order_status { get; set; }
        [Required]
        public string Order_Type{ get; set; }
    }

}
