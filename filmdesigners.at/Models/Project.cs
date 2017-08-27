using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public int OwnerID { get; set; }

        public string Name { get; set; }
    }
}
