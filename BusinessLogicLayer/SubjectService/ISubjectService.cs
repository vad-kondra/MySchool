using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.SubjectService.Dtos;
using DataAccessLayer.Models.Enums;

namespace BusinessLogicLayer.SubjectService
{
    public interface ISubjectService
    {
        Task<SubjectDto> GetByIdAsync(long id);
        Task<List<SubjectDto>> GetAllAsync();
        Task AddOneAsync(SubjectDto item);
        void Update(SubjectDto item);
        Task DeleteOneAsync(long id);
        SubjectDto GetById(long id);
        string GetTypeName(SubjectType type, Language lang);
    }
}