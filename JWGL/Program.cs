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
            LoginUI.Login();
            LoginUI.logout();
        }
    }
}
