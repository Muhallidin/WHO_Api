using System;
using System.Collections.Generic;
using System.Text;
using who.domain.Common;
using who.domain.Entities;

namespace who.application.ViewModel
{
    public class AuthorCourseVm : User
    {
        internal int CA_Id { get; set; }
        public Author Author { get; set; }
        public Courses Courses { get; set; }
    }
}
