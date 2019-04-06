using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.BLL;
using JWGL.Model;
namespace JWGL
{
    class LoginUI
    {
        

        internal static void Login()
        {
            Console.WriteLine(@"
╔══════════════════════════════════════╗
║╔════════════════════════════════════╗║
║║                                    ║║
║║       简易教务管理系统  V0.1       ║║
║║                                    ║║
║╚════════════════════════════════════╝║
╚══════════════════════════════════════╝
");
            Console.Write("请输入的你ID:");
            string id = Console.ReadLine();
            Console.Write("请输入的你密码:");
            string pass = Console.ReadLine();
            string err;
            bool result = LoginBLL.Login(id, pass,out err);
            if (result)
            {
                Welcome();
                if (BaseBLL.User.GetUserType() == UserType.Admin) AdminUI.GetCmd();
            }
            else
            {
                Console.WriteLine(err);
            }
        }

        internal static void logout()
        {
            throw new NotImplementedException();
        }

        internal static void Welcome()
        {
            string[] typeMap = { "未认证的", "认证的", "管理员", "教师", "学生" };
            Console.WriteLine(typeMap[(int)BaseBLL.User.GetUserType()] + BaseBLL.User.Name+",欢迎你!");
        }
    }
}
