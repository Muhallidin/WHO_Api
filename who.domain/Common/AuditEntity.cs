using System;
using System.Collections.Generic;
using System.Text;

namespace who.domain.Common
{
    public class AuditEntity : User
    {
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }

    }
}
