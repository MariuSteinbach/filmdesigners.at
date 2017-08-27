using System.ComponentModel.DataAnnotations;

namespace filmdesigners.at.Models.MemberViewModels
{
    public class MemberEditViewModel
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public MemberStatus MemberStatus { get; set; }
    }
    public enum MemberStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}