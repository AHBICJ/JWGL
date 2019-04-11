using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.BLL;
namespace JWGL
{
    class TeacherUI
    {
        protected enum Type { MAIN, ASSIGN, QUERY, INFO }
        #region Menu UI
        protected static void Show(Type t)
        {
            switch (t)
            {
                case Type.MAIN:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║             学生操作菜单             ║
║         ====================         ║
║  1--成绩登记         2--课程查询     ║
║  3--个人信息                         ║
║  4--注销             0--退出         ║
╚══════════════════════════════════════╝
");
                    Console.Write("请选择要进行的操作：");
                    break;
                case Type.ASSIGN:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
                  成绩登记                  
所有课程信息
学期课程编号  课程名称  任课老师姓名");
                    break;

                case Type.QUERY:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║               课程查询               ║
学期课程ID  课程名称  已选课人数");
                    break;
                case Type.INFO:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║               个人信息               ║");
                    break;
            }

        }
        #endregion

        public static ReturnType TeacherMain()
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
                        SetGradeUI();
                        break;
                    case '2':
                        QueryCourseUI();
                        break;
                    case '3':
                        InfoUI();
                        break;
                    case '4':
                        return ReturnType.RELOGIN;
                }
            }
        }

        private static void InfoUI()
        {
            Show(Type.INFO);
            Console.WriteLine(TeacherBLL.ShowInfo());
        }

        private static void QueryCourseUI()
        {
            Show(Type.QUERY);
            string[] res = TeacherBLL.QueryCourse();
            foreach (string str in res) Console.WriteLine(str);
        }


        private static void SetGradeUI()
        {
            Show(Type.ASSIGN);
            QueryCourseUI();
            string cid = Tool.ReadLineWithTip("请输入要登记成绩的学期课程ID：");
            if (TeacherBLL.HasThisCourse(cid))
            {
                string confirm = Tool.ReadLineWithTip("输入所有选修此课程的学生的成绩(是/否/取消)？(Y/N/Q)");
                if (confirm[0]=='Y' || confirm[0] == 'y')
                {
                    string[] ids = TeacherBLL.GetIds(cid);
                    int i = 0;
                    if (ids.Length == 0)
                    {
                        Console.WriteLine("没有需要录入成绩的同学！");
                        return;
                    }
                    while (i < ids.Length)
                    {
                        string grade = Tool.ReadLineWithTip("请输入" + StudentBLL.GetName(ids[i]) + "的成绩");
                        try
                        {
                            double g = double.Parse(grade);
                            if (!TeacherBLL.AssignOnce(cid, ids[i], g)) Console.WriteLine("该学生已有成绩");
                        }
                        catch
                        {
                            Console.WriteLine("成绩输入错误");
                        }
                    }
                }
                else if (confirm[0] == 'n' || confirm[0] == 'N')
                {
                    string id = Tool.ReadLineWithTip("请输入要登记成绩的学生学号：");
                    string grade = Tool.ReadLineWithTip("请输入" + id + "的成绩");
                    try
                    {
                        double g = double.Parse(grade);
                        if (!TeacherBLL.AssignOnce(cid,id,g)) Console.WriteLine("学号输入错误,或该学生已有成绩");
                    }
                    catch
                    {
                        Console.WriteLine("成绩输入错误");
                    }
                }
                else
                {
                    Console.WriteLine("操作已经取消");
                }
            }
            else
            {
                Console.WriteLine("没有这门课");
            }
        }
    }
}
