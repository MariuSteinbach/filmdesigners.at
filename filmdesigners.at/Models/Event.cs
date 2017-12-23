using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Event
    {
        public string EventID { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Teaser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created { get; set; }
    }
}
