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
        public static void StudentMain()
        {
            Console.WriteLine(@"
学生操作菜单：
");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    ChooseCourse(); break;
                case "2":
                    QuitCourse();break;
                case "3":
                    return;
            }
        }

        private static void QuitCourse()
        {
            throw new NotImplementedException();
        }

        private static void ChooseCourse()
        {
            PrintTermCourses();
            Console.WriteLine("请输入你要选择的课程编号：");
            string s = Console.ReadLine();
        }

        private static void PrintTermCourses()
        {
            TermCourse[] tms = TermCourseBLL.GetAllTermCourse();
            foreach(TermCourse tm in tms)
            {
                string info = TermCourseBLL.GetCourseDetail(tm);
            }
        }

        internal static ReturnType GetCmd()
        {
            throw new NotImplementedException();
        }
    }
}
