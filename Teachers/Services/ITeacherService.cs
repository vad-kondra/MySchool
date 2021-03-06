using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Teachers.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task AddOneAsync(Teacher item);
        Task AddRangeAsync(List<Teacher> items);
        Task UpdateOneAsync(Teacher item);
        Task DeleteOneAsync(Teacher item);
    }
}