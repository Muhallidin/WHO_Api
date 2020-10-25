using System;
using System.Collections.Generic;
using who.domain.Common;

namespace who.domain.Entities
{
    public class CourseEnroll : User
    {

        public int Student_Id { get; set; }
        public int Course_Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
