using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.GradeRepository
{
    public interface IGradeRepository
    {
        List<Grade> GetAll();
        Task<List<Grade>> GetAllAsync();
        Task AddOneAsync(Grade grade);
        Grade GetById(long id);
        Task<Grade> GetByIdAsync(long id);
        void Update(Grade item);
    }
}