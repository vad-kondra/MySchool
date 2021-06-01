using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.SubjectRepository
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task AddOneAsync(Subject item);
        Task<Subject> GetByIdAsync(long id);
        Subject GetById(long id);
        void Update(Subject item);
    }
}