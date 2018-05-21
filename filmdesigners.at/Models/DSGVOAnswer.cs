using System;
namespace filmdesigners.at.Models
{
    public class DSGVOAnswer
    {
        public int ID
		{
			get;
			set;
		}
        public string Email
    	{
    		get;
			set;
    	}
		public bool Accepted
		{
    		get;
    		set;
		}
		public DateTime AcceptedAt
		{
    		get;
    		set;
		}
		public string AcceptedFrom
		{
    		get;
    		set;
		}
    }
}
