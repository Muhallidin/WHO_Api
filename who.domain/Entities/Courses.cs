using System;
using System.Collections.Generic;
using System.Text;
using who.domain.Common;

namespace who.domain.Entities
{
    public class Courses : AuditEntity
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Course { get; set; }
    }
}
