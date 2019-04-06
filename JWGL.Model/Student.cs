using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Student:Person
    {
        private static int SID = 136001;
        List<CourseAndMark> courses;
        public Student(string name,string password) : base(name, password) {
            courses = new List<CourseAndMark>();
        }
             
        public override string GetNewID()
        {
            return string.Format("S{0}", SID++);
        }
        public override UserType GetUserType()
        {
            return UserType.Student;
        }
        // 选课
        public void AddCourse(CourseAndMark course)
        {
            courses.Add(course);
        }
        // 退课
        public bool RemoveCourse(string courseID)
        {
            foreach(CourseAndMark c in courses)
            {
                if (c.CourseID ==courseID)
                {
                    return courses.Remove(c);
                }
            }
            return false;
        }
        public CourseAndMark[] GetCourseMarks()
        {
            return courses.ToArray();
        }

        internal void setCourseMarks(string courseID, double mark)
        {
            foreach (CourseAndMark c in courses)
            {
                if (c.CourseID == courseID) c.Mark = mark;
            }
        }

    }

    [Serializable]
    public class CourseAndMark
    {
        string courseID;
        double mark;
        public CourseAndMark(string courseID)
        {
            this.courseID = courseID;
            this.mark = -1;
        }
        public CourseAndMark(string coureseID,double mark) : this(coureseID)
        {
           this.mark = mark;
        }
        public string CourseID
        {
            get => courseID;
        }
        public double Mark
        {
            get => mark;
            set => mark=value;
        }
    }
}
