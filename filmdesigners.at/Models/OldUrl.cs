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
    public class OldUrl
    {
        /// <summary>
        /// Gets or sets the old URL identifier.
        /// </summary>
        /// <value>The old URL identifier.</value>
        public string OldUrlID { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>The member identifier.</value>
        public string MemberID { get; set; }
    }
}
