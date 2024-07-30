using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly Context context;

        public ProductRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Insert(Product entity)
        {
            int recordsAffected = 0;

            this.context.Product.Add(entity);
            recordsAffected = this.context.SaveChanges();
            
            return recordsAffected > 0;
        }

        public bool Update(Product entity)
        {
            int recordsAffected = 1;

            var product = this.context.Product.Where(x => x.ProductId == entity.ProductId).FirstOrDefault();
            if (product != null)
            {
                product.Name = entity.Name;
                product.Status = entity.Status;
                product.Stock = entity.Stock;
                product.Description = entity.Description;
                product.Price = entity.Price;

                recordsAffected = this.context.SaveChanges();
            }

            return recordsAffected > 0;
        }

        public Product? Get(long ProductId)
        {
            return this.context.Product.Where(x => x.ProductId == ProductId).FirstOrDefault();
        }

        public List<Product> Get()
        {
            return this.context.Product.ToList();
        }
    }
}
