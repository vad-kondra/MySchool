using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.SubjectService.Dtos;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using DataAccessLayer.Repositories.SubjectRepository;

namespace BusinessLogicLayer.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<SubjectDto> GetByIdAsync(long id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            var subjectDto = _mapper.Map<SubjectDto>(subject);

            return subjectDto;
        }

        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            var subjectDtos = _mapper.Map<List<SubjectDto>>(subjects);

            return subjectDtos;
        }
        
        public async Task AddOneAsync(SubjectDto item)
        {
            var subject = _mapper.Map<Subject>(item);
            await _subjectRepository.AddOneAsync(subject);
        }

        public void Update(SubjectDto item)
        {
            var subject = _mapper.Map<Subject>(item);
            
            _subjectRepository.Update(subject);
        }

        public Task DeleteOneAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public SubjectDto GetById(long id)
        {
            var subject = _subjectRepository.GetById(id);
            var subjectDto = _mapper.Map<SubjectDto>(subject);

            return subjectDto;
        }

        public string GetTypeName(SubjectType type, Language lang)
        {
            var result = string.Empty;
            if (lang == Language.English)
            {
                result = type.ToString();
            }
            else
            {
                switch (type)
                {
                    case SubjectType.ElementarySchools:
                        result = "Начальная школа";
                        break;
                    case SubjectType.MiddleSchools:
                        result = "Средняя школа";
                        break;
                    case SubjectType.HighSchools:
                        result = "Старшая школа";
                        break;
                }
            }
            return result;
        }
    }
}