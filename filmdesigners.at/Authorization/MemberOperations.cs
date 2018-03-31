using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace filmdesigners.at.Authorization
{
    public static class MemberOperations
    {
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement
            {
                Name = Constants.CreateOperationName
            };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement
            {
                Name = Constants.ReadOperationName
            };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement
            {
                Name = Constants.UpdateOperationName
            };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement
            {
                Name = Constants.DeleteOperationName
            };
        public static OperationAuthorizationRequirement Approve =
            new OperationAuthorizationRequirement
            {
                Name = Constants.ApproveOperationName
            };
        public static OperationAuthorizationRequirement Reject =
            new OperationAuthorizationRequirement
            {
                Name = Constants.RejectOperationName
            };
        public static OperationAuthorizationRequirement ReadMemberState =
            new OperationAuthorizationRequirement
            {
                Name = Constants.ReadMemberStateOperationName
            };
    }

    public class Constants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";
        public static readonly string AddUserOperationName = "Add";
        public static readonly string RemoveUserOperationName = "Remove";
        public static readonly string ReadMemberStateOperationName = "ReadMemberState"; 

        public static readonly string MembersAdministratorsRole = "MembersAdministrator";
        public static readonly string MembersManagersRole = "MembersManager";
        public static readonly string ChapterAdministratorsRole = "ChaptersAdministrator";
        public static readonly string EnrollmentAdministratorsRole = "EnrollmentsAdministrator";
        public static readonly string RolesAdministratorsRole = "RolesAdministrator";
        public static readonly string UsersAdministratorsRole = "UsersAdministrator";
        public static readonly string JobsAdministratorsRole = "JobsAdministrator";
        public static readonly string EventsAdministratorsRole = "EventsAdministrator";
    }
}
