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

        public int JobId { get; set; }

        public string Name { get; set; }
        public bool Male { get; set; }
        public string Street { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string OtherContact { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Deathday { get; set; }
        public string Picture { get; set; }
        public string Languages { get; set; }
        public string InternationalExperiences { get; set; }
        public string Education { get; set; }
        public string Activities { get; set; }
        public string Galleries { get; set; }
        public string Awards { get; set; }
        public string Notes { get; set; }
        public string EMail { get; set; }

        public bool Active { get; set; }
        public bool Locked { get; set; }
        public bool Resigned { get; set; }
        public bool Paused { get; set; }
        public DateTime LastUpdate { get; set; }



        public MemberStatus Status { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Job Job { get; set; }
    }

    public enum MemberStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
