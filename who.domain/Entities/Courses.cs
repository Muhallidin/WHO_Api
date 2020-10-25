using who.domain.Common;

namespace who.domain.Entities
{
    public class Courses : User
    {
        public string CourseCode { get; set; }
        public string Course { get; set; }
    }
}
