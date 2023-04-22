using Mango.Web.Models;
using Mango.Web.Services.IServices;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
