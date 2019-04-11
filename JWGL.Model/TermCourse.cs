using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class TermCourse
    {
        string courseID, teacherID, id;
        List<string> students;
        public string CourseID
        {
            get => courseID;
        }
        public string TeacherID
        {
            get => teacherID;
        }
        public string ID
        {
            get => id;
        }
        public TermCourse(string courseID,string teacherID)
        {
            this.teacherID = teacherID;
            this.courseID = courseID;
            id = courseID + teacherID;
            students = new List<string>();
        }
        public bool AddStudent(Student student)
        {
            if (!students.Contains(student.ID))
            {
                students.Add(student.ID);
                return true;
            }
            return false;
        }
        public bool AddStudent(string studentID)
        {
            if (!students.Contains(studentID))
            {
                students.Add(studentID);
                return true;
            }
            return false;
        }
        public bool RemoveStudent(Student student)
        {
            if (students.Contains(student.ID))
            {
                students.Remove(student.ID);
                return true;
            }
            return false;
        }
        public bool RemoveStudent(string studentID)
        {
            if (students.Contains(studentID))
            {
                students.Remove(studentID);
                return true;
            }
            return false;
        }
        public String[] GetStudents()
        {
            return students.ToArray();
        }
        public int GetStudentsNum()
        {
            return students.Count;
        }

        public bool HasStudentByID(string studentID)
        {
            return students.Contains(studentID);
        }



    }
}
