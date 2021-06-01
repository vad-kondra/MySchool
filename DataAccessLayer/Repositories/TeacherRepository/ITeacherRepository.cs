using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.TeacherRepository
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(long id);
        Task<Teacher> AddOneAsync(Teacher item);
        Task<List<Teacher>> AddRangeAsync(List<Teacher> items);
        void Update(Teacher item);
        Task DeleteOneAsync(Teacher item);
    }
}