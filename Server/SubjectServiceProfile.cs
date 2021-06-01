using AutoMapper;
using BusinessLogicLayer.SubjectService.Dtos;
using DataAccessLayer.Models;

namespace Server
{
    public class SubjectServiceProfile : Profile
    {
        public SubjectServiceProfile()
        {
            CreateMap<Subject, SubjectDto>().ReverseMap();
        }
    }
}