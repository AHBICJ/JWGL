using System;

using System.Collections.Generic;
using JWGL.Model;
namespace JWGL.DAL
{
	/// <summary>
	/// CourseDAL 的摘要说明。
	/// </summary>
	[Serializable]
	public class CourseDAL
	{
		private List<Course> courses;
		
		public CourseDAL()
		{
			this.courses = new List<Course>();
		}

		/// <summary>
		/// 增加新课程
		/// </summary>
		/// <param name="newCourse"></param>
		/// <returns></returns>
		public bool Add(Course course)
		{
			for(int i=0;i<courses.Count;i++)
			{
                if (course.ID == courses[i].ID)
				{
					return false;
				}
			}
			this.courses.Add(course);
			return true;
		}


		/// <summary>
		/// 根据课程编号检索课程
		/// </summary>
		/// <param name="courseID"></param>
		/// <returns></returns>
		public Course Retrieve(string courseID)
		{
			for(int i=0;i<courses.Count;i++)
			{
                if (courseID == courses[i].ID)
				{
					return courses[i];
				}
			}			
			return null;
		}

		/// <summary>
		/// 检索所有课程
		/// </summary>
		/// <returns></returns>
		public Course[] RetrieveAll()
		{
			return courses.ToArray();
            
		}

		/// <summary>
		/// 根据课程ID删除课程
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool Remove(string courseID)
		{
			for(int i=0;i<courses.Count;i++)
			{
                if (courseID == courses[i].ID)
				{
					courses.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
	}
}
