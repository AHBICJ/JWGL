using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Teacher:Person
    {
        public static int teacherID = 1;
        static int currentYear = 2010;
        public Teacher(string name, string password) : base(name, password) { }

        public override string GetNewID()
        {
            if (DateTime.Today.Year > currentYear)
            {
                currentYear = DateTime.Today.Year;
                teacherID = 1;
            }
            return string.Format("T{0}{1:000}", currentYear,teacherID++);
        }

        public override UserType GetUserType()
        {
            return UserType.Teacher;
        }
    }
}
