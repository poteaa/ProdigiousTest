using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataAcess;
using ProdigiousTest.Model.Entities;

namespace ProdigiousTest.Model.Managers
{
    public class UserManager : BaseManager
    {
        protected override IList<User> GetAll<User>()
        {
            return base.GetAll<User>();
        }
    }
}
