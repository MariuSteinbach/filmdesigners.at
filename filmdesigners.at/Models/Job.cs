using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string toString()
        {
            return Name;
        }
    }
}