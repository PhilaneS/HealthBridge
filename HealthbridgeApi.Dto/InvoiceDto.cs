using System;
using System.Collections.Generic;
using System.Text;

namespace HealthbridgeApi.Dto
{
    public class InvoiceDto
    {
        public long InvoiceId { get; set; }

        [CustomDate(ErrorMessage ="Cannot be a date in the future")]
        public System.DateTime InvoiceDateTime { get; set; }
        public long PatientId { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
