using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Contexts;
using Dapper;

namespace CleanArchitecture.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly DapperContext context;

        public ProductRepository(DapperContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Insert(Product entity)
        {
            using var connection = this.context.CreateConnection();

            string sql = "INSERT INTO Product(Name, Status, Stock, Description, Price) VALUES(@Name, @Status, @Stock, @Description, @Price)";
            var parameters = new { entity.Name, entity.Status, entity.Stock, entity.Description, entity.Price };

            var recordsAffected = connection.Execute(sql, param: parameters);
            return recordsAffected > 0;
        }

        public bool Update(Product entity)
        {
            using var connection = this.context.CreateConnection();

            string sql = "UPDATE Product SET Name = @Name, Status = @Status, Stock = @Stock, Description = @Description, Price = @Price WHERE ProductId = @ProductId";
            var parameters = new { entity.Name, entity.Status, entity.Stock, entity.Description, entity.Price, entity.ProductId };

            var recordsAffected = connection.Execute(sql, param: parameters);
            return recordsAffected > 0;
        }

        public Product? Get(long ProductId)
        {
            using var connection = this.context.CreateConnection();

            string sql = "SELECT * FROM Product WHERE ProductId = @ProductId";
            var parameters = new { ProductId };

            return connection.QueryFirstOrDefault<Product>(sql, param: parameters);
        }
    }
}
