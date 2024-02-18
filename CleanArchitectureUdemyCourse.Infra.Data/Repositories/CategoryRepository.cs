using CleanArchitectureUdemyCourse.Domain.Entities;
using CleanArchitectureUdemyCourse.Domain.Repositories;
using CleanArchitectureUdemyCourse.Infra.Data.Context;

namespace CleanArchitectureUdemyCourse.Infra.Data.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category category = await _dbContext.Categories.FindAsync(id);

            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = _dbContext.Categories.ToList();
            return categories;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            _dbContext.Categories.Remove(await GetCategoryByIdAsync(id));

            await _dbContext.SaveChangesAsync();
        }

    }
}
