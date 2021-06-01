using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models
{
    public class Subject
    {
        public long SubjectId { get; set; }

        public string Title { get; set; }

        public SubjectType Type { get; set; }
    }
}