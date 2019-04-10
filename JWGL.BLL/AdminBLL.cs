using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    public class AdminBLL:BaseBLL
    {
        #region TermCourse 
        public static bool AddTermCourse(string cid, string tid,out string err)
        {
            if (courses.Retrieve(cid) == null)
            {
                err = "课程ID错误";
                return false;
            }
            if (teachers.Retrieve(tid) == null)
            {
                err = "教师ID错误";
                return false;
            }
            if (termCourses.Add(new TermCourse(cid, tid))){
                err = "";
                return true;
            }
            else
            {
                err = "课程重复";
                return false;
            }
        }
        public static bool RemoveTermCourse(string id)
        {
            return termCourses.Remove(id);
        }
        public static bool ModifyTermCourse(string id, string newtid,out string err)
        {
            TermCourse tc = termCourses.Retrieve(id);
            Course c = courses.Retrieve(tc.CourseID);
            Person t = teachers.Retrieve(newtid);
            if (t==null)
            {
                err = "新ID对应的教师不存在";
                return false;
            }
            if (termCourses.Add(new TermCourse(c.ID, newtid)))
            {
                termCourses.Remove(id);
                err = "";
                return true;
            }
            else
            {
                err = "课程重复，此教师已经上该课";
                return false;
            }
        }

        public static string[] QueryTermCourse()
        {
            List<string> res = new List<string>();
            TermCourse[] tcs = termCourses.RetrieveAll();
            foreach (TermCourse tc in tcs)
            {
                Course c = courses.Retrieve(tc.CourseID);
                Person t = teachers.Retrieve(tc.TeacherID);
                res.Add(string.Format("{0} {1} {2}", tc.ID, c.Name, t.Name));
            }
            return res.ToArray();
        }
        public static string QueryTermCourse(string id)
        {
            TermCourse tc = termCourses.Retrieve(id);
            if (tc == null) return "";
            Course c = courses.Retrieve(tc.CourseID);
            Person t = teachers.Retrieve(tc.TeacherID);
            return string.Format("{0} {1} {2}", tc.ID, c.Name, t.Name);
        }

        public static bool isExistedTermCourse(string id)
        {
            return termCourses.Retrieve(id) != null;
        }

        #endregion

        #region Course 
        public static void AddCourse(string cid,string name,double point)
        {
            courses.Add(new Course(cid,name,point));
        }
        public static bool RemoveCourse(string id)
        {
            return courses.Remove(id);
        }
        public static bool ModifyCourse(string id, double point)
        {
            Course c = courses.Retrieve(id);
            if (c == null) return false;
            c.Point = point;
            return true;
        }

        public static Course[] QueryCourse()
        {
            return courses.RetrieveAll();
        }
        public static Course QueryCourse(string id)
        {
            return courses.Retrieve(id);
        }

        public static bool isExistedCourse(string id)
        {
            return courses.Retrieve(id) != null;
        }

        #endregion

        #region Teacher 
        public static void AddTeacher(string name,string pass)
        {
            teachers.Add(new Teacher(name, pass));
        }
        public static bool RemoveTeacher(string id)
        {
            if (termCourses.TeachCourses(id).Length != 0) return false;
            return teachers.Remove(id);
        }
        public static bool ModifyTeacher(string id,string pass)
        {
            return teachers.ChangPW(id, pass);
        }

        public static Person[] QueryTeacher()
        {
            return teachers.RetrieveAll();
        }
        public static Person QueryTeacher(string id)
        {
            return teachers.Retrieve(id);
        }

        public static bool isExistedTeacher(string id)
        {
            return teachers.Retrieve(id)!=null;
        }

        #endregion

        #region Student
        public static void AddStudent(string name, string pass)
        {
            students.Add(new Student(name, pass));
        }

        public static bool isExistedStudent(string id)
        {
            return students.Retrieve(id) != null;
        }

        public static bool RemoveStudent(string id)
        {
            return students.Remove(id);
        }

        public static bool ModifyStudent(string id,string pass)
        {
            return students.ChangPW(id, pass);
        }

        public static Person[] QueryStudent()
        {
            return students.RetrieveAll();
        }

        public static Person QueryStudent(string tid)
        {
            return students.Retrieve(tid);
        }

        #endregion


    }
}
