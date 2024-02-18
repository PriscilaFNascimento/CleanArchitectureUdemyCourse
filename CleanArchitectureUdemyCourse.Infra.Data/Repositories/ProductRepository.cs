using CleanArchitectureUdemyCourse.Domain.Entities;
using CleanArchitectureUdemyCourse.Domain.Repositories;
using CleanArchitectureUdemyCourse.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureUdemyCourse.Infra.Data.Repositories
{
    public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            IEnumerable<Product> products = await _dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductAndCategoryByIdAsync(int id)
        {
            Product product = await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = await _dbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            _dbContext.Products.Remove(await GetProductByIdAsync(id));

            await _dbContext.SaveChangesAsync();
        }

    }
}
