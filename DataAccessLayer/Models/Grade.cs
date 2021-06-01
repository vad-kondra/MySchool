using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Grade
    {
        public long GradeId { get; set; }

        public int Number { get; set; }
        
        public string Parallel { get; set; }
        
        public long TeacherId { get; set; }
        
        public Teacher Teacher { get; set; }
        
        public List<Student> Students { get; set; }
    }
}