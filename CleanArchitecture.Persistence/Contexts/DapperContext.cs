using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SQLite;

namespace CleanArchitecture.Persistence.Contexts
{
    public class DapperContext
    {
        readonly IConfiguration configuration;
        readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.connectionString = this.configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("ConnectionStrings/Default not found.");
        }

        public IDbConnection CreateConnection() => new SQLiteConnection(this.connectionString);
    }
}
