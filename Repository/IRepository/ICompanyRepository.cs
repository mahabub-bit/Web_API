using Project_01.Data;
using Project_01.Models;

namespace Project_01.Repository.IRepository
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company> UpdateAsync(Company entity);
    }
}
