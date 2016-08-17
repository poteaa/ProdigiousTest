using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataAcess;
using ProdigiousTest.Model.Entities;
using ProdigiousTest.Security;

namespace ProdigiousTest.Model.Managers
{
    public class LoginManager : BaseManager
    {
        public string Login(string userName, string password)
        {
            UserDA userDA = new UserDA();
            userDA.UserName = userName;
            IBaseSecurity baseSecurity = new BaseSecurity();            
            userDA.Password = baseSecurity.Encrypt(password); ;
            return userDA.Login();
        }
        public bool ValidateToken(string userName, string token)
        {
            UserDA userDA = new UserDA();
            userDA.UserName = userName;
            return userDA.ValidateToken(token);
        }
        protected override IList<User> GetAll<User>()
        {
            return base.GetAll<User>();
        }
    }
}
