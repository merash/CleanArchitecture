using CleanArchitecture.Application.Interface.External;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.External.Contexts;
using Newtonsoft.Json;
using RestSharp;

namespace CleanArchitecture.External.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly RestSharpContext _applicationContext;

        public DiscountRepository(RestSharpContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public Discount Get()
        {
            using var connection = _applicationContext.CreateConnection();

            RestRequest request = new RestRequest("api/GetDiscount", Method.Get);
            var response = connection.Get(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("API de Equivalencias no disponible, favor revisar con sistemas");
            var content = JsonConvert.DeserializeObject<List<Discount>>(response.Content);

            return content.FirstOrDefault();
        }
    }
}
