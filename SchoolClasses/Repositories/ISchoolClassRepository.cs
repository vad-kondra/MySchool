using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace SchoolClasses.Repositories
{
    public interface ISchoolClassRepository
    {
        Task<List<Clazz>> GetAllAsync();
        Task<Clazz> GetByIdAsync(int id);
        Task AddOneAsync(Clazz item);
        Task AddRangeAsync(List<Clazz> items);
        Task UpdateOneAsync(Clazz item);
        Task DeleteOneAsync(Clazz item);
    }
}