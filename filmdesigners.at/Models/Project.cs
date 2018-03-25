using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Project
    {
        public string ProjectID { get; set; }

        public string OwnerID { get; set; }

        public string Name { get; set; }

        public ProjectType Type { get; set; }

        public DateTime Date { get; set; }

        public string Countries { get; set; }

        public string Regiesseur { get; set; }

        public string Production { get; set; }

        public string Link { get; set; } 

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public enum ProjectType
    {
        Kino,
        TV
    }
}
