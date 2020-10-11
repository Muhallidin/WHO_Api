using System;
using System.Collections.Generic;
using System.Text;
using who.domain.Common;

namespace who.application.ViewModel
{
    public class CourseEnrollVm: User
    {
        public int Students_Id { get; set; }
        public int Course_Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
