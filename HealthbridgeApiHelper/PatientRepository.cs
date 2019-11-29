using HealthbridgeApi.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HealthbridgeApiHelper
{
    public class PatientRepository : IPatientRepository
    {
        // private readonly = System.Configuration.ConfigurationManager.
        public PatientRepository()
        {

        }

        public object DeletePatient(PatientDto dtoToDelete)
        {
            IRestRequest request = new RestRequest("api/patient/" + dtoToDelete.PatientId + "/deletePatient", Method.DELETE);
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

        public PatientDto GetPatientById(int? id)
        {
            // var client = new RestClient(baseUrl);
            var request = new RestRequest("api/patient/" + id, Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
            };

            request.AddHeader("Cache-Control", "no-cache");
            request.RequestFormat = DataFormat.Json;

            var response = Rest.Execute<PatientDto>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }

        public IEnumerable<PatientDto> GetPatients()
        {
            // var client = new RestClient(baseUrl);
            var request = new RestRequest("api/patient", Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
            };

            request.AddHeader("Cache-Control", "no-cache");
            request.RequestFormat = DataFormat.Json;

            var response = Rest.Execute<List<PatientDto>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }

        public bool Register(PatientDto data)
        {
            IRestRequest request = new RestRequest("api/patient/register", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;
            request.AddBody(data);

            var response = Rest.Execute<bool>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }

        public object updatePatient(PatientDto data)
        {
            IRestRequest request = new RestRequest("api/patient/update", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = JsonSerializer.Default;
            request.AddBody(data);

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
