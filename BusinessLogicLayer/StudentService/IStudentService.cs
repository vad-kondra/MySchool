using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.StudentService.Dtos;

namespace BusinessLogicLayer.StudentService
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(long id);
        Task<StudentDto> AddOneAsync(StudentDto item);
        void Update(StudentDto item);
        Task DeleteOneAsync(long id);
        StudentDto GetById(long id);
        string GetFullFIO(StudentDto studentDto);
    }
}