using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.StudentService.Dtos;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.StudentRepository;

namespace BusinessLogicLayer.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, 
                              IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentsDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return studentsDtos;
        }

        public StudentDto GetById(long id)
        {
            var student = _studentRepository.GetById(id);
            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }
        
        public async Task<StudentDto> GetByIdAsync(long id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            var studentDto = _mapper.Map<Student, StudentDto>(student);

            return studentDto;
        }

        public async Task<StudentDto> AddOneAsync(StudentDto item)
        {

            var student = _mapper.Map<Student>(item);
            var addedStudent = await _studentRepository.AddOneAsync(student);
            var addedStudentDto = _mapper.Map<StudentDto>(addedStudent);

            return addedStudentDto;
        }
        
        public void Update(StudentDto item)
        {
            var student = _mapper.Map<StudentDto, Student>(item);
            
            _studentRepository.Update(student);
        }

        public async Task DeleteOneAsync(long id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student != null)
            {
                await _studentRepository.DeleteOneAsync(student);
            }
        }

        public string GetFullFIO(StudentDto studentDto)
        {
            var result = string.Empty;
            var lastName = "Нет имени";

            if (studentDto.LastName == null)
            {
                return lastName;
            }

            result += GetFirstUpperLetter(studentDto.LastName) + " ";
            result += GetOnlyFirstUpperLetter(studentDto.FirstName);
            result += GetOnlyFirstUpperLetter(studentDto.MiddleName);

            return result;
        }

        private string GetOnlyFirstUpperLetter(string word)
        {
            return !string.IsNullOrEmpty(word) 
                ? word.Substring(0, 1).ToUpper() + "." 
                : string.Empty;
        }
        
        private string GetFirstUpperLetter(string word)
        {
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            
            return !string.IsNullOrEmpty(word) 
                ? textInfo.ToTitleCase(word)
                : string.Empty;
        }
    }
}