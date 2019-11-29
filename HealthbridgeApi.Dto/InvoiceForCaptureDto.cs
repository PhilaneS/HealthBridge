using System;
using System.Collections.Generic;
using System.Text;

namespace HealthbridgeApi.Dto
{
    public class InvoiceForCaptureDto
    {
        public long InvoiceId { get; set; }

        [CustomDate(ErrorMessage = "Cannot be a date in the future")]
        public System.DateTime InvoiceDateTime { get; set; }
        public long PatientId { get; set; }
        public ICollection<InvoiceLineDto> InvoiceLine { get; set; }


    }
}
