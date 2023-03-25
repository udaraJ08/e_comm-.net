using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace e_comm.Models
{
    public class OrderModal
    {
        [AllowNull]
        public int Device_id { get; set; }
        [AllowNull]
        public int User_id { get; set; }
        [AllowNull]
        public string Shipping_address { get; set; }
        [AllowNull]
        public string Billing_address { get; set; }
        [AllowNull]
        public string Shipping_method { get; set; }
        [AllowNull]
        public string Order_type { get; set; } //Standard or customized
        [AllowNull]
        public string Amount { get; set; } //Standard or customized
        [AllowNull]
        public int Vga { get; set; } //Standard or customized
        [AllowNull]
        public int Ram { get; set; } //Standard or customized
        [AllowNull]
        public int Hard { get; set; } //Standard or customized
        [AllowNull]
        public int Processor { get; set; } //Standard or customized
    }
}
