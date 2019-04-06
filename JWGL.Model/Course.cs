using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Course
    {
        string courseID;
        string courseName;
        double couresePoint;
        public Course(string courseID,string courseName,double couresePoint)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.couresePoint = couresePoint;
        }
        public string CourseID
        {
            get => courseID;
        }
        public string CourseName
        {
            get => courseName;
        }

        public double CoursePoint
        {
            get => couresePoint;
        }
    }
}
