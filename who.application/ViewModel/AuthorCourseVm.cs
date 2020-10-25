using who.domain.Common;
using who.domain.Entities;

namespace who.application.ViewModel
{
    public class AuthorCourseVm : AuthorCourse
    {
        public int Id { get; set; }
        public AuthorVm Author { get; set; }
        public CoursesVm Courses { get; set; }
    }
}
