using System;
using System.Collections.Generic;
using System.Linq;
using _20._101_Kargin_authorization.Model.Database;
using System.Text;
using System.Threading.Tasks;

namespace _20._101_Kargin_authorization.Model
{
    enum LoginCondition
    {
        Failed,
        Success
    }
    enum Role
    {
        None,
        Client,
        Manager,
        Administrator
    }
    class LoginManager
    {
        public Role AuthorizationRole = Role.None;
        public LoginCondition CheckLogInData(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return LoginCondition.Failed;
            }
            else
            {
                var dbContext = new AuthorizationContext();
                var query = from user in dbContext.Users where user.Login == login && user.Password == password select user;
                if (query.Count() > 0)
                {
                    if (query.First().Login == login && query.First().Password == password)
                    {
                        AuthorizationRole = GetRoleOnString(query.First().RoleId);
                        return LoginCondition.Success;
                    }
                }
                    return LoginCondition.Failed;
                

            }
        }
        public Role GetRoleOnString(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return Role.Client;
                case 2:
                    return Role.Manager;
                case 3:
                    return Role.Administrator;
            }
            return Role.None;
        }
    }
}
