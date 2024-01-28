using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TaskManagementSystem.Context;

namespace TaskManagementSystem.RolesProvider
{
    public class RolesProviders : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            DBContext dbContext = new DBContext();
            // get roleid
            int roleId = dbContext.Users.SingleOrDefault(x => x.Username == username).RoleId;
            //get rolename
            var roleName = (from r in dbContext.Roles
                            where r.RoleId == roleId
                            select r.RoleName).ToArray();
            return roleName;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}