using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.GradeService.Dtos;

namespace BusinessLogicLayer.GradeService
{
    public interface IGradeService
    {
        List<GradeDto> GetAll();
        Task<List<GradeDto>> GetAllAsync();
        GradeDto GetById(long id);
        Task<GradeDto> GetByIdAsync(long id);
        Task AddOneAsync(GradeDto item);
        Task UpdateOneAsync(GradeDto item);
        Task DeleteOneAsync(long id);

        string GetGradeTitle(GradeDto grade);
        void Update(GradeDto grade);
    }
}