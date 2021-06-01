using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.TeacherService.Dtos;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.TeacherRepository;

namespace BusinessLogicLayer.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, 
                              IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            var teacherDtos = _mapper.Map<List<Teacher>, List<TeacherDto>>(teachers);

            return teacherDtos;
        }
        public async Task<TeacherDto> GetByIdAsync(long id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            var teacherDto = _mapper.Map<Teacher, TeacherDto>(teacher);

            return teacherDto;
        }
        
        public async Task<TeacherDto> AddOneAsync(TeacherDto item)
        {
            var teacher = _mapper.Map<Teacher>(item);
            var addedTeacher = await _teacherRepository.AddOneAsync(teacher);
            var addedTeacherDto = _mapper.Map<TeacherDto>(addedTeacher);

            return addedTeacherDto;
        }

        public async Task<List<TeacherDto>> AddRangeAsync(List<TeacherDto> items)
        {
            var teachers = _mapper.Map<List<Teacher>>(items);
            var addedTeachers = await _teacherRepository.AddRangeAsync(teachers);
            var addedTeacherDtos = _mapper.Map<List<TeacherDto>>(addedTeachers);

            return addedTeacherDtos;
        }

        public void Update(TeacherDto item)
        {
            var teacher = _mapper.Map<TeacherDto, Teacher>(item);
            
            _teacherRepository.Update(teacher);
        }

        public async Task DeleteOneAsync(long id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher != null)
            {
                await _teacherRepository.DeleteOneAsync(teacher);
            }
        }
    }
}