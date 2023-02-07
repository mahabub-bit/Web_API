using Project_01.Models;

namespace Project_01.Repository.IRepository
{
    public interface ICategoryTypeRepository : IRepository<CategoryType>
    {
        Task<CategoryType> UpdateAsync(CategoryType entity);
    }
}
