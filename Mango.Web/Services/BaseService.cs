using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            responseModel = new ResponseDto();
            _httpClient = httpClient;
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                        Encoding.UTF8, "application/json");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
