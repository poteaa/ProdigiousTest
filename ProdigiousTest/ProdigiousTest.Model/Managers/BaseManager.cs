using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.Model.Managers
{
    public class BaseManager
    {
        protected virtual IList<T> GetAll<T>() where T : class
        {
            return null;
        }
    }
}
