using Project_01.Data;
using Project_01.Models;
using Project_01.Repository.IRepository;

namespace Project_01.Repository
{
    public class CategoryTypeRepository : Repository<CategoryType>, ICategoryTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CategoryType> UpdateAsync(CategoryType entity)
        {
            _db.CategoryTypes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
