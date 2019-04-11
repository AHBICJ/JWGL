using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    public class TeacherBLL : BaseBLL
    {
        public static string ShowInfo()
        {
            Teacher tea = (Teacher)user;
            return tea.Name;
        }

        public static string[] QueryCourse()
        {
            Teacher tea = (Teacher)user;
            List<string> res = new List<string>();
            TermCourse[] tms = termCourses.TeachCourses(tea.ID);
            foreach (TermCourse tc in tms)
            {
                Course c = courses.Retrieve(tc.CourseID);
                res.Add(string.Format("{0} {1} {2}", tc.ID, c.Name,tc.GetStudentsNum()));
            }
            return res.ToArray();
        }

        public static bool HasThisCourse(string id)
        {
            Teacher tea = (Teacher)user;
            TermCourse[] tms = termCourses.TeachCourses(tea.ID);
            foreach (TermCourse tc in tms)
            {
                if (tc.ID == id) return true;
            }
            return false;
        }

        public static bool AssignOnce(string cid, string id, double g)
        {
            TermCourse tc = termCourses.Retrieve(cid);
            Student st = (Student)students.Retrieve(id);
            CourseAndMark[] cms = st.GetCourseMarks();
            foreach(CourseAndMark cm in cms)
            {
                if (cm.CourseID == tc.CourseID && cm.Mark != -1)
                {
                    cm.Mark = g;
                    return false;
                }
            }
            return false;
        }

        public static string[] GetIds(string cid)
        {
            List<string> res = new List<string>();
            TermCourse tc = termCourses.Retrieve(cid);
            return tc.GetStudents().ToArray();
        }
    }
}
