using JWGL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.BLL;
namespace JWGL
{
    class StudentUI
    {
        protected enum Type { MAIN, ADD, REMOVE, QUERY, INFO }
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
║  1--课程选修         2--课程退选     ║
║  3--成绩查询         4--个人信息     ║
║  5--注销             0--退出         ║
╚══════════════════════════════════════╝
");
                    Console.Write("请选择要进行的操作：");
                    break;
                case Type.ADD:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
                  课程选修                  
所有课程信息
学期课程编号  课程名称  任课老师姓名");
                    break;
                     
                case Type.REMOVE:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║               课程退选               ║
已选课程信息
课程编号  课程名称  任课老师姓名");
                    break;
                case Type.QUERY:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║               成绩查询               ║
成绩信息
课程名   状态/成绩");
                    break;
                case Type.INFO:
                    Console.WriteLine(@"
╔══════════════════════════════════════╗
║               个人信息               ║");
                    break;
            }
            
        }
        #endregion

        public static ReturnType StudentMain()
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
                        ChooseCourseUI();
                        break;
                    case '2':
                        QuitCourseUI();
                        break;
                    case '3':
                        QueryGradeUI();
                        break;
                    case '4':
                        InfoUI();
                        break;
                    case '5':
                        return ReturnType.RELOGIN;
                }
            }
        }

        private static void InfoUI()
        {
            Console.WriteLine(StudentBLL.ShowInfo());
        }

        private static void QueryGradeUI()
        {
            string[] res = StudentBLL.QueryGrade();
            foreach (string str in res) Console.WriteLine(str);
        }

        private static void QuitCourseUI()
        {
            Show(Type.REMOVE);
            PrintAllChosenCourseID();
            string s = Tool.ReadLineWithTip("请输入你要退选的课程编号：");
            if (StudentBLL.CheckHasChosenCourse(s)){
                if (StudentBLL.RemoveCourse(s)) Console.WriteLine("退选成功");
            }
            else
            {
                Console.WriteLine("你没有选择该门课程，或该门课已经有成绩");
            }
        }

        private static void PrintAllChosenCourseID()
        {
            string[] courseId = StudentBLL.GetAllCourseID();
            foreach (string str in courseId) Console.WriteLine(str);
        }

        private static void ChooseCourseUI()
        {
            Show(Type.ADD);
            PrintAllTermCourses();
            string s = Tool.ReadLineWithTip("请输入你要选择的学期课程编号：");
            if (TermCourseBLL.RetrieveTermCourse(s) == null)
            {
                Console.WriteLine("不存在此门课程！");
                return;
            }
            if (!StudentBLL.CheckHasChosenTermCourse(s))
            {
                if (StudentBLL.AddTermCourse(s)) Console.WriteLine("成功选取该门课程！"); else Console.WriteLine("未满足先修课要求！");
            }
            else
            {
                Console.WriteLine("已经选过同名的课程");
            }
        }

        private static void PrintAllTermCourses()
        {
            string[] termCourse = AdminBLL.QueryTermCourse();
            foreach (string str in termCourse) Console.WriteLine(str);
        }
    }
}
