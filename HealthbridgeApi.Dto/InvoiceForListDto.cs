using System;
using System.Collections.Generic;
using System.Text;

namespace HealthbridgeApi.Dto
{
   public class InvoiceForListDto
    {
        public long InvoiceId { get; set; }
        public string InvoiceDateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
