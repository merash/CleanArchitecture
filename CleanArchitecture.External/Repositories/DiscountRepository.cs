using CleanArchitecture.Application.Interface.External;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.External.Contexts;
using Newtonsoft.Json;
using RestSharp;

namespace CleanArchitecture.External.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        readonly RestSharpContext restSharpContext;

        public DiscountRepository(RestSharpContext restSharpContext)
        {
            this.restSharpContext = restSharpContext ?? throw new ArgumentNullException(nameof(restSharpContext));
        }

        public int GetDiscount()
        {
            using var connection = this.restSharpContext.CreateConnection();

            RestRequest request = new RestRequest("api/GetDiscount", Method.Get);
            var response = connection.Get(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("API GetDiscount no disponible");
            var discounts = JsonConvert.DeserializeObject<List<Discount>>(response.Content ?? "[]");

            return discounts?.FirstOrDefault()?.discount ?? 0;
        }
    }
}
