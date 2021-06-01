using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Teacher
    {
        public long TeacherId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public long? GradeId { get; set; }
        
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }
    }
}