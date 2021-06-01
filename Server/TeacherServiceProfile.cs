using AutoMapper;
using BusinessLogicLayer.TeacherService.Dtos;
using DataAccessLayer.Models;

namespace Server
{
    public class TeacherServiceProfile : Profile
    {
        public TeacherServiceProfile()
        {
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}