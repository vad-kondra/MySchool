using AutoMapper;
using BusinessLogicLayer.StudentService.Dtos;
using DataAccessLayer.Models;

namespace Server
{
    public class StudentServiceProfile : Profile
    {
        public StudentServiceProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}