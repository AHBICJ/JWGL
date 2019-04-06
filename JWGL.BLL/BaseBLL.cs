using System;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
	/// <summary>
	/// BaseBLL 的摘要说明。
	/// </summary>
	public class BaseBLL
	{		
		protected static Person user;
		protected static AdminDAL admins;
		protected static StudentDAL students;
		protected static TeacherDAL teachers;
		protected static CourseDAL courses;
		protected static TermCourseDAL termCourses;

		protected BaseBLL(){}
		static BaseBLL()
		{
			admins = DataFileAccess.GetAdmins();
			students = DataFileAccess.GetStudents();
			teachers = DataFileAccess.GetTeachers();
			courses = DataFileAccess.GetCourses();
			termCourses = DataFileAccess.GetTermCourses();
		}

		public static Person User
		{
			get{return user;}
		}

        public static void SaveAll()
        {
            DataFileAccess.SaveAdmins(admins);
            DataFileAccess.SaveCourses(courses);
            DataFileAccess.SaveStudents(students);
            DataFileAccess.SaveTeachers(teachers);
            DataFileAccess.SaveTermCourses(termCourses);
        }
    }
}
