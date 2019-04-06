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

        public static void InitData()
        {
            
            TermCourse tm1 = new TermCourse("C001", "T2010901");
            TermCourse tm2 = new TermCourse("C001", "T2010902");
            TermCourse tm3 = new TermCourse("C002", "T2010902");
            
            termCourses.AddNewTermCourse(tm1);
            termCourses.AddNewTermCourse(tm2);
            termCourses.AddNewTermCourse(tm3);

        }

        #region Teacher 
        public static void AddTeacher(string name,string pass)
        {
            teachers.Add(new Teacher(name, pass));
        }
        public static bool RemoveTeacher(string id)
        {
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
