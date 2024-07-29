using Microsoft.Extensions.Configuration;
using RestSharp;

namespace CleanArchitecture.External.Contexts
{
    public class RestSharpContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _urlAPIDiscount;

        public RestSharpContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _urlAPIDiscount = _configuration.GetSection("External").GetSection("mockAPI").Value ?? throw new ArgumentNullException("Section External/mockAPI not found.");
        }

        public IRestClient CreateConnection() => new RestClient(_urlAPIDiscount);
    }
}
