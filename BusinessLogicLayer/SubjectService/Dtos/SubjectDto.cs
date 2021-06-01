using DataAccessLayer.Models.Enums;

namespace BusinessLogicLayer.SubjectService.Dtos
{
    public class SubjectDto
    {
        public long SubjectId { get; set; }

        public string Title { get; set; }

        public SubjectType Type { get; set; }
    }
}