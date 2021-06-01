using AutoMapper;
using BusinessLogicLayer.GradeService.Dtos;
using DataAccessLayer.Models;

namespace Server
{
    public class GradeServiceProfile : Profile
    {
        public GradeServiceProfile()
        {
            CreateMap<Grade, GradeDto>().ReverseMap();
        }
    }
}