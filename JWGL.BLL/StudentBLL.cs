using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    public class StudentBLL : BaseBLL
    {
        public static bool CheckHasChosenTermCourse(string s)
        {
            Student stu = (Student)user;
            TermCourse tm = termCourses.Retrieve(s);
            CourseAndMark[] courses = stu.GetCourseMarks();
            foreach (CourseAndMark cm in courses)
            {
                if (cm.CourseID == tm.CourseID) return true;
            }
            return false;
        }

        public static bool CheckHasChosenCourse(string s)
        {
            Student stu = (Student)user;
            CourseAndMark[] courses = stu.GetCourseMarks();
            foreach (CourseAndMark cm in courses)
            {
                if (cm.CourseID == s && cm.Mark==-1) return true;
            }
            return false;
        }

        public static void AddTermCourse(string s)
        {
            Student stu = (Student)user;
            TermCourse tm = termCourses.Retrieve(s);
            stu.AddCourse(new CourseAndMark(tm.CourseID, tm.TeacherID));
        }

        public static string[] GetAllCourseID()
        {
            List<string> res = new List<string>();
            Student stu = (Student)user;
            foreach (CourseAndMark cm in stu.GetCourseMarks())
            {
                Course c = courses.Retrieve(cm.CourseID);
                res.Add(string.Format("{0} {1} {2}", c.ID, c.Name, cm.TeacherID));
            }
            return res.ToArray();
        }

        protected static string GetTermCourseIDByCourseID(string s)
        {
            Student stu = (Student)user;
            CourseAndMark[] cms = stu.GetCourseMarks();
            foreach (CourseAndMark cm in cms)
            {
                if (cm.CourseID == s) return cm.CourseID + cm.TeacherID;
            }
            return "";
        }
        public static void RemoveCourse(string s)
        {
            Student stu = (Student)user;
            string id = GetTermCourseIDByCourseID(s);
            TermCourse tm = termCourses.Retrieve(id);
            tm.RemoveStudent(stu.ID);
            stu.RemoveCourse(s);
        }

        public static void RemoveStudentCourse(string id)
        {
            TermCourse tm = termCourses.Retrieve(id);
            string[] stus = tm.GetStudents();
            foreach (string str in stus)
            {
                Student stu = (Student) students.Retrieve(str);
                stu.RemoveCourse(tm.CourseID);
            }
        }

        public static String ShowInfo()
        {
            Student stu = (Student)user;
            return stu.Name;
        }

        public static string[] QueryGrade()
        {
            List<string> res = new List<string>();
            Student stu = (Student)user;
            foreach (CourseAndMark cm in stu.GetCourseMarks())
            {
                Course c = courses.Retrieve(cm.CourseID);
                res.Add(string.Format("{0} {1}", c.Name, cm.Mark == -1 ? "在修" : cm.Mark.ToString()));
            }
            return res.ToArray();
        }
    }
}
