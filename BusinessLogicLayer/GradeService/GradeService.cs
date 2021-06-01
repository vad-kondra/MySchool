using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.GradeService.Dtos;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.GradeRepository;

namespace BusinessLogicLayer.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, 
                            IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public List<GradeDto> GetAll()
        {
            var grades = _gradeRepository.GetAll();
            var gradeDtos = _mapper.Map<List<GradeDto>>(grades);

            return gradeDtos;
        }
        
        public async Task<List<GradeDto>>GetAllAsync()
        {
            var grades = await _gradeRepository.GetAllAsync();
            var gradeDtos = _mapper.Map<List<GradeDto>>(grades);

            return gradeDtos;
        }

        public GradeDto GetById(long id)
        {
            var grade = _gradeRepository.GetById(id);
            var gradeDto = _mapper.Map<GradeDto>(grade);

            return gradeDto;
        }
        
        public async Task<GradeDto> GetByIdAsync(long id)
        {
            var grade = await _gradeRepository.GetByIdAsync(id);
            var gradeDto = _mapper.Map<GradeDto>(grade);

            return gradeDto;
        }

        public async Task AddOneAsync(GradeDto item)
        {
            var grade = _mapper.Map<Grade>(item);
            await _gradeRepository.AddOneAsync(grade);
        }
        
        public Task UpdateOneAsync(GradeDto item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteOneAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public string GetGradeTitle(GradeDto grade)
        {
            if (grade != null)
            {
                return grade.Number + " - " + grade.Parallel;
            }

            return "Не выбран";
        }

        public void Update(GradeDto item)
        {
            var grade = _mapper.Map<Grade>(item);
            
            _gradeRepository.Update(grade);
        }
    }
}