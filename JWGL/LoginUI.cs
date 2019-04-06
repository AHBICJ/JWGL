using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.BLL;
using JWGL.Model;
namespace JWGL
{
    enum ReturnType { RELOGIN, EXIT, ERROR }
    class LoginUI
    {
        internal static ReturnType Login()
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
            if (LoginBLL.Login(id, pass, out err))
            {
                Welcome();
                switch (BaseBLL.User.GetUserType())
                {
                    case UserType.Admin: return AdminUI.GetCmd();
                    case UserType.Teacher: return TeacherUI.GetCmd();
                    case UserType.Student: return StudentUI.GetCmd();
                }
            }
            else
            {
                Console.WriteLine(err);
                return ReturnType.ERROR;
            }
            return ReturnType.EXIT;
        }

        internal static void Logout()
        {
            BaseBLL.SaveAll();
        }

        internal static void Welcome()
        {
            string[] typeMap = { "未认证的", "认证的", "管理员", "教师", "学生" };
            Console.WriteLine(typeMap[(int)BaseBLL.User.GetUserType()] + BaseBLL.User.Name+",欢迎你!");
        }
    }
}
