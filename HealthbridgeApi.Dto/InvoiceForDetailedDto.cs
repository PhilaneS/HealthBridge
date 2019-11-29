using System;
using System.Collections.Generic;
using System.Text;

namespace HealthbridgeApi.Dto
{
    public class InvoiceForDetailedDto
    {
        public long PatientId { get; set; }
        public string InvoiceDateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<InvoiceLineDto> InvoiceLine { get; set; }
    }
}
