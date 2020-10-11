using System;
using System.Collections.Generic;
using System.Text;
using who.domain.Common;

namespace who.application.ViewModel
{
    public class CourseVm : User
    {
        //public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Course { get; set; }
    }
}
