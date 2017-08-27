using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string OwnerID { get; set; }

        public string Name { get; set; }
        public MemberStatus Status { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public enum MemberStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
