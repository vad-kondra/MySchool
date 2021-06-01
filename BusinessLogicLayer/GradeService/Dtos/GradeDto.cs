using System.Collections.Generic;
using BusinessLogicLayer.StudentService.Dtos;
using BusinessLogicLayer.TeacherService.Dtos;

namespace BusinessLogicLayer.GradeService.Dtos
{
    public class GradeDto
    {
        public long GradeId { get; set; }

        public int Number { get; set; }
        
        public string Parallel { get; set; }
        
        public TeacherDto Teacher { get; set; }

        public List<StudentDto> Students { get; set; }
    }
}