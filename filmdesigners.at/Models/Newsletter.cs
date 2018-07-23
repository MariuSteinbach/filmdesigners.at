using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Newsletter
    {
        public string NewsletterID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<Member> Recipients { get; set; }
        public List<Job> RecipientDepartments { get; set; }
    }
}
