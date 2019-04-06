using System;

using System.Collections.Generic;
using JWGL.Model;
namespace JWGL.DAL
{
	/// <summary>
	/// CourseDAL ��ժҪ˵����
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
		/// �����¿γ�
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
		/// ���ݿγ̱�ż����γ�
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
		/// �������пγ�
		/// </summary>
		/// <returns></returns>
		public Course[] RetrieveAll()
		{
			return courses.ToArray();
            
		}

		/// <summary>
		/// ���ݿγ�IDɾ���γ�
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
