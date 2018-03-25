using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Enrollment
    {
        public string EnrollmentID { get; set; }
        public string ProjectID { get; set; }
        public string MemberID { get; set; }
        public string JobId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
        public virtual Job Job { get; set; }
    }
}
