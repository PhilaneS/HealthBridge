using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HealthbridgeApi.Dto;
using RestSharp;

namespace HealthbridgeApiHelper
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public InvoiceRepository()
        {
        }

        public IEnumerable<InvoiceForListDto> GetInvoices()
        {
            var request = new RestRequest("api/invoice", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;

            var response = Rest.Execute<List<InvoiceForListDto>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }

        public object GetInvoiceById(int id)
        {
            var request = new RestRequest("api/invoice/"+ id, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;

            var response = Rest.Execute<object>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }
        public object UpdateInvoice(InvoiceForCaptureDto data)
        {
            IRestRequest request = new RestRequest("api/invoice/update", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;
            request.AddBody(data);

            var response = Rest.Execute<InvoiceForCaptureDto>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }
        public object AddInvoice(InvoiceForCaptureDto data)
        {
            IRestRequest request = new RestRequest("api/invoice/capture", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;
            request.AddBody(data);

            var response = Rest.Execute<InvoiceForCaptureDto>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }
        public object DeleteInvoiceItem(long id)
        {
            IRestRequest request = new RestRequest("api/invoiceLine/" + id + "/deleteInvoiceLine", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;

            var response = Rest.Execute<object>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }

    }
}
