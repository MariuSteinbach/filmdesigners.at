using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class SearchResult
    {
        public IEnumerable<Award> Awards { get; set; }
        public IEnumerable<Chapter> Chapter { get; set; }
        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<Job> Job { get; set; }
        public IEnumerable<Member> Member { get; set; }
        public IEnumerable<Project> Project { get; set; }
    }
}
