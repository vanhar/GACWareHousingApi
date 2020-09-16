using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GACWareHousingScheduler.Helpers
{
    public static class HttpClientHelper
    {
        static readonly string baseApirUrl = "https://localhost:44356/";

        public static string salesOrderApi = "api/SalesOrder";

        public static HttpClient Object()
        {
            var httpClient = new HttpClient(){BaseAddress = new Uri(baseApirUrl)};
            var byteArray = Encoding.ASCII.GetBytes("gac:password:xunittest");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            return httpClient;
        }
    }
}
