using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(long id);
        Task<Student> AddOneAsync(Student item);
        Task<List<Student>> AddRangeAsync(List<Student> items);
        void Update(Student item);
        Task DeleteOneAsync(Student item);
        Student GetById(long id);
    }
}