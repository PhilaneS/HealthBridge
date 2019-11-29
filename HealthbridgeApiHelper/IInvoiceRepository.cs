using HealthbridgeApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthbridgeApiHelper
{
    public interface IInvoiceRepository
    {
        IEnumerable<InvoiceForListDto> GetInvoices();
        object GetInvoiceById(int id);

        object UpdateInvoice(InvoiceForCaptureDto invoice );

        object AddInvoice(InvoiceForCaptureDto invoice);

        object DeleteInvoiceItem(long id);
    }
}
