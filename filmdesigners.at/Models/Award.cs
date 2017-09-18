using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Award
    {
        public int AwardID { get; set; }
        public int MemberID { get; set; }
        public int ProjectID { get; set; }
        public int JobID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
        public virtual Job Job { get; set; }
    }
}
