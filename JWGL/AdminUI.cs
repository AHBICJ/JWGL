using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.BLL;
using JWGL.Model;

namespace JWGL
{
    class AdminUI
    {
        internal enum Type {MAIN,TMA,SMA,CMA,TCMA}
        #region Menu UI
        internal static void Show(Type t)
        {
            switch (t)
            {
                case Type.MAIN:Console.WriteLine(@"
╔══════════════════════════════════════╗
║             系统管理菜单             ║
║         ====================         ║
║  1--教师管理         2--学生管理     ║
║  3--课程管理         4--学期课程管理 ║
║  5--注销             0--退出         ║
╚══════════════════════════════════════╝
");
                    break;
                case Type.TMA: Console.WriteLine(@"
╔══════════════════════════════════════╗
║             教师管理菜单             ║
║         ====================         ║
║  1--新增             2--删除         ║
║  3--修改             4--查询         ║
║  0--返回至系统管理菜单               ║
╚══════════════════════════════════════╝
");
                    break;
                case Type.SMA:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║             学生管理菜单             ║
║         ====================         ║
║  1--新增             2--删除         ║
║  3--修改             4--查询         ║
║  0--返回至系统管理菜单               ║
╚══════════════════════════════════════╝
");
                    break;
                case Type.CMA:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║             课程管理菜单             ║
║         ====================         ║
║  1--新增             2--删除         ║
║  3--修改             4--查询         ║
║  0--返回至系统管理菜单               ║
╚══════════════════════════════════════╝
");
                    break;
                case Type.TCMA:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║           学期课程管理菜单           ║
║         ====================         ║
║  1--新增             2--删除         ║
║  3--修改             4--查询         ║
║  0--返回至系统管理菜单               ║
╚══════════════════════════════════════╝
");
                    break;
            }
            Console.Write("请选择要进行的操作：");
        }
        #endregion

        internal static ReturnType GetCmd()
        {
            while (true)
            {
                Show(Type.MAIN);
                string input = Console.ReadLine();
                Console.Clear();
                switch (input[0])
                {
                    case '0':
                        return ReturnType.EXIT;
                    case '1':
                        TMA();
                        break;
                    case '2':
                        SMA();
                        break;
                    case '3':
                        CMA();
                        break;
                    case '4':
                        TCMA();
                        break;
                    case '5':
                        return ReturnType.RELOGIN;
                }
            }
        }

        private static string ReadLineWithTip(string tip)
        {
            Console.Write(tip);
            return Console.ReadLine();
        }

        private static void TCMA()
        {
            Show(Type.TCMA);
            return;
        }

        private static void CMA()
        {
            Show(Type.CMA);
            return;
        }

        #region Student UI
        private static void AddStudentUI()
        {
            string name = ReadLineWithTip("请输入学生姓名：");
            string pass = ReadLineWithTip("请输入学生密码：");
            AdminBLL.AddStudent(name, pass);
        }

        private static void RemoveStudentUI()
        {
            string id = ReadLineWithTip("请输入要删除的学生ID：");
            if (AdminBLL.isExistedStudent(id))
            {
                string confirm = ReadLineWithTip("确认要删除该学生吗？(Y/N)");
                if (confirm[0] == 'y' || confirm[0] == 'Y')
                    Console.WriteLine(AdminBLL.RemoveStudent(id) ? "操作成功" : ">>>> 操作失败：未知原因");
                else
                    Console.WriteLine("操作已经取消");
            }
            else
            {
                Console.WriteLine(">>>> 错误提示： 指定的学生不存在！");
            }
        }

        private static void ModifyStudentUI()
        {
            string id = ReadLineWithTip("请输入要修改的学生ID：");
            if (AdminBLL.isExistedStudent(id))
            {
                string pass = ReadLineWithTip("请输入新密码:");
                AdminBLL.ModifyStudent(id, pass);
            }
            else
            {
                Console.WriteLine(">>>> 错误提示： 指定的学生不存在！");
            }
        }

        private static void QueryStudentUI()
        {
            string tid = ReadLineWithTip("******** 查询学生记录 ***********\n请输入要查询的学生ID(否则显示所有学生信息)：");
            Console.WriteLine("ID  姓名");
            if (tid == "")
            {
                Person[] students = AdminBLL.QueryStudent();
                foreach (Person p in students)
                {
                    Console.WriteLine(p.ID + " " + p.Name);
                }
            }
            else 
            {
                Person t = AdminBLL.QueryStudent(tid);
                if (t == null)
                {
                    Console.WriteLine("查无此人");
                }
                else Console.WriteLine(t.ID + " " + t.Name);
            }
        }

        private static void SMA()
        {
            while (true)
            {
                Show(Type.SMA);
                string input = Console.ReadLine();
                try
                {
                    switch (input[0])
                    {
                        case '0': return;
                        case '1': AddStudentUI(); break;
                        case '2': RemoveStudentUI(); break;
                        case '3': ModifyStudentUI(); break;
                        case '4': QueryStudentUI(); break;
                    }
                }
                catch
                {
                    Console.WriteLine("出现错误");
                }
                
            }

        }
        #endregion

        #region Teacher UI

        private static void AddTeacherUI()
        {
            string name = ReadLineWithTip("请输入教师姓名：");
            string pass = ReadLineWithTip("请输入教师密码：");
            AdminBLL.AddTeacher(name, pass);
        }

        private static void RemoveTeacherUI()
        {
            string id = ReadLineWithTip("请输入要删除的教师ID：");
            if (AdminBLL.isExistedTeacher(id))
            {
                string confirm = ReadLineWithTip("确认要删除该教师吗？(Y/N)");
                if (confirm[0] == 'y' || confirm[0] == 'Y')
                    Console.WriteLine(AdminBLL.RemoveTeacher(id) ? "操作成功" : ">>>> 操作失败：未知原因");
                else
                    Console.WriteLine("操作已经取消");
            }
            else
            {
                Console.WriteLine(">>>> 错误提示： 指定的教师不存在！");
            }
        }

        private static void ModifyTeacherUI()
        {
            string id = ReadLineWithTip("请输入要修改的教师ID：");
            if (AdminBLL.isExistedTeacher(id))
            {
                string pass = ReadLineWithTip("请输入新密码:");
                AdminBLL.ModifyTeacher(id,pass);
            }
            else
            {
                Console.WriteLine(">>>> 错误提示： 指定的教师不存在！");
            }
        }

        private static void QueryTeacherUI()
        {
            string tid = ReadLineWithTip("******** 查询教师记录 ***********\n请输入要查询的教师ID(否则显示所有教师信息)：");
            Console.WriteLine("ID  姓名");
            // 查询所有老师信息
            if (tid == "")
            {
                Person[] teachers = AdminBLL.QueryTeacher();
                foreach (Person p in teachers) Console.WriteLine(p.ID + " " + p.Name);
            }
            else // 查询单个老师信息
            {
                Person t = AdminBLL.QueryTeacher(tid);
                if (t == null)
                {
                    Console.WriteLine("查无此人");
                }
                else Console.WriteLine(t.ID + " " + t.Name);
            }
        }

        /// <summary>
        /// Teacher Manage
        /// </summary>
        private static void TMA()
        {
            while (true)
            {
                Show(Type.TMA);
                string input = Console.ReadLine();
                Console.Clear();
                try
                {
                    switch (input[0])
                    {
                        case '0': return;
                        case '1': AddTeacherUI(); break;
                        case '2': RemoveTeacherUI(); break;
                        case '3': ModifyTeacherUI(); break;
                        case '4': QueryTeacherUI(); break;
                    }
                }
                catch
                {
                    Console.WriteLine("出现错误");
                }
            }
        }
        #endregion
    }
}
