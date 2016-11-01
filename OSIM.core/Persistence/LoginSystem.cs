using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIM.core.Persistence
{
    public interface ILogin
    {
        int Login();
    }

    class LoginSystem : ILogin
    {
        public int Login()
        {
            return 1;
        }
    }
}
