using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;
using JWGL.BLL;
namespace JWGL
{
    class Program
    {
        static void Main(string[] args)
        {
            while (LoginUI.Login() == ReturnType.RELOGIN)
            {
                LoginUI.Logout();
            }
            LoginUI.Logout();
        }
    }
}
