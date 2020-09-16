using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GACWareHousingApi;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace GACWareHousingApi.XUnitTests
{
    public class SalesOrderApiTest
    {
        
        private readonly HttpClient _client;

        public SalesOrderApiTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
            var byteArray = Encoding.ASCII.GetBytes("gac:password:xunittest");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetAllSalesOrders(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/SalesOrder/");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", 1)]
        public async Task GetSalesOrder(string method, int id)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/SalesOrder/{id}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("POST")]
        public async Task POSTSalesOrder(string method)
        {
            var xml = "<SalesOrders><SalesOrder OrderCode=\"OD0001\" CustomerCode=\"C000001\" OrderDate=\"2020-09-16 14:35\">< SalesOrderDetails>"
            +"<SalesOrderDetail OrderCode = \"OD0001\" ProductCode = \"P00001\" Quantity = \"10\" ></SalesOrderDetail>"
            +"</ SalesOrderDetails ></ SalesOrder ></SalesOrders> ";
            var data = new StringContent(xml, Encoding.UTF8, "application/json");

            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/SalesOrder");

            //Act
            var response = await _client.PostAsync(request.RequestUri, data);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("DELETE", 1)]
        public async Task DeleteSalesOrder(string method, int id)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/SalesOrder/{id}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
