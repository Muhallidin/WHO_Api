using System;
using System.Collections.Generic;
using System.Text;

namespace who.domain.Common
{
    public class Name : User
    {
      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
