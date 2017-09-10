using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int ProjectID { get; set; }
        public int MemberID { get; set; }
        public int JobId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
        public virtual Job Job { get; set; }
    }
}
