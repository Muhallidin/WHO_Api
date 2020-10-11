using System;
using System.Collections.Generic;
using System.Text;

namespace who.domain.Entities
{
    public class CourseEnroll : AuthorCourse
    {
        public CourseEnroll()
        {
            this.Students = new List<Student>();
        }

        public int ECId { get; set; }
        public IList<Student> Students { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }

}
