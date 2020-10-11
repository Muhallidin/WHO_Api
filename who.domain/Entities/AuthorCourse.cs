using System;
using System.Collections.Generic;
using System.Text;
using who.domain.Common;

namespace who.domain.Entities
{
    public class AuthorCourse : AuditEntity 
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public Courses Courses { get; set; }
    }
}
