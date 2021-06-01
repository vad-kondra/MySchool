using BusinessLogicLayer.GradeService.Dtos;

namespace BusinessLogicLayer.StudentService.Dtos
{
    public class StudentDto
    {
        public long StudentId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public long? GradeId { get; set; }
        
        public GradeDto Grade { get; set; }
    }
}