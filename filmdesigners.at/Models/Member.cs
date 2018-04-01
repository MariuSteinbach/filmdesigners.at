/******************************************************************************/
/*                                                                            */
/* CONFIDENTIAL                                                               */
/* __________________________________________________________________________ */
/*                                                                            */
/*  [2018] Marius Steinbach                                                   */
/*  All Rights Reserved.                                                      */
/*                                                                            */
/* NOTICE:  All information contained herein is, and remains                  */
/* the property of Marius Steinbach.                                          */
/* The intellectual and technical concepts contained                          */
/* herein are proprietary to Marius Steinbach                                 */
/* and are protected by trade secret or copyright law.                        */
/* Dissemination of this information or reproduction of this material         */
/* is strictly forbidden unless prior written permission is obtained          */
/* from Marius Steinbach.                                                     */
/*                                                                            */
/******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Models
{
    public class Member
    {
        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>The member identifier.</value>
        public string MemberId { get; set; }
        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>The owner identifier.</value>
        public string OwnerID { get; set; }
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public string JobId { get; set; }
        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public int Priority { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:filmdesigners.at.Models.Member"/> is male.
        /// </summary>
        /// <value><c>true</c> if male; otherwise, <c>false</c>.</value>
        public bool Male { get; set; }
        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public int ZIP { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string Website { get; set; }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string Fax { get; set; }
        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        public string Mobile { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the other contact.
        /// </summary>
        /// <value>The other contact.</value>
        public string OtherContact { get; set; }
        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Gets or sets the deathday.
        /// </summary>
        /// <value>The deathday.</value>
        public DateTime Deathday { get; set; }
        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>The picture.</value>
        public string Picture { get; set; }
        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        /// <value>The languages.</value>
        public string Languages { get; set; }
        /// <summary>
        /// Gets or sets the international experiences.
        /// </summary>
        /// <value>The international experiences.</value>
        public string InternationalExperiences { get; set; }
        /// <summary>
        /// Gets or sets the education.
        /// </summary>
        /// <value>The education.</value>
        public string Education { get; set; }
        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        public string Activities { get; set; }
        /// <summary>
        /// Gets or sets the galleries.
        /// </summary>
        /// <value>The galleries.</value>
        public string Galleries { get; set; }
        /// <summary>
        /// Gets or sets the awards.
        /// </summary>
        /// <value>The awards.</value>
        public string Awards { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets the EM ail.
        /// </summary>
        /// <value>The EM ail.</value>
        public string EMail { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:filmdesigners.at.Models.Member"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:filmdesigners.at.Models.Member"/> is locked.
        /// </summary>
        /// <value><c>true</c> if locked; otherwise, <c>false</c>.</value>
        public bool Locked { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:filmdesigners.at.Models.Member"/> is resigned.
        /// </summary>
        /// <value><c>true</c> if resigned; otherwise, <c>false</c>.</value>
        public bool Resigned { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:filmdesigners.at.Models.Member"/> is paused.
        /// </summary>
        /// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
        public bool Paused { get; set; }
        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public MemberStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the enrollments.
        /// </summary>
        /// <value>The enrollments.</value>
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        public virtual Job Job { get; set; }
    }

    public enum MemberStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
