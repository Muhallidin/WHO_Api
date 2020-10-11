using System;
using System.Collections.Generic;
using System.Text;

namespace who.domain.Interface
{
   
    public interface IName
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string FamilyName { get; set; }

    }
}


