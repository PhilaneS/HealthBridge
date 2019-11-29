using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthbridgeApiHelper
{
    public static class Rest
    {
        private static bool _ranOnce;
        private static readonly RestClient client = new RestClient(ConfigurationManager.AppSettings["baseUrl"]);

        private static void InitializeOnce()
        {
            if (_ranOnce) return;
            client.AddDefaultHeader("Content-Type", "application/json");
            _ranOnce = true;
        }

        public static IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            Debug.WriteLine("Making Request to API Server with Resource: " + request.Resource);
            InitializeOnce();

            //Ignore bad certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
            return client.Execute<T>(request);
        }

        public static async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            Debug.WriteLine("Making Async Request to API Server with Resource: " + request.Resource);
            InitializeOnce();

            //ignore bad certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
            return await client.ExecuteTaskAsync<T>(request);
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
