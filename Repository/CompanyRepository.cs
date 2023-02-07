using Project_01.Data;
using Project_01.Models;
using Project_01.Repository.IRepository;

namespace Project_01.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Company> UpdateAsync(Company entity)
        {
            entity.CC2 = DateTime.Now;
            _db.Companies.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
