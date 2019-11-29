using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthbridgeApi.Dto
{
    public class InvoiceLineDto
    {
        public long InvoiceLineId { get; set; }
        public long InvoiceId { get; set; }

        [Range(1, Int64.MaxValue, ErrorMessage = "Quantity cannot be a negative number and cannot be zero")]
        [Required]
        public double Qty { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "You must provide charecters not exceeding 10 charecters")]
        [Required]
        public string Code { get; set; }

        [StringLength(250, MinimumLength = 1, ErrorMessage = "You must provide charecters not exceeding 250 charecters")]
        [Required]
        public string Description { get; set; }

        [Range(1d, (double)decimal.MaxValue, ErrorMessage = "Quantity cannot be a negative number and cannot be zero")]
        [Required]
        public decimal LineTotal { get; set; }
    }
}
