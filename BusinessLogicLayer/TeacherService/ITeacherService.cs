using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.TeacherService.Dtos;

namespace BusinessLogicLayer.TeacherService
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetAllAsync();
        Task<TeacherDto> GetByIdAsync(long id);
        Task<TeacherDto> AddOneAsync(TeacherDto item);
        Task<List<TeacherDto>> AddRangeAsync(List<TeacherDto> items);
        void Update(TeacherDto item);
        Task DeleteOneAsync(long id);
    }
}