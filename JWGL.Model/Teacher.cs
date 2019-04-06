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
        static int teacherID = 1;
        public Teacher(string name, string password) : base(name, password) { }

        public override string GetNewID()
        {
            return string.Format("T2010{0:000}", teacherID++);
        }

        public override UserType GetUserType()
        {
            return UserType.Teacher;
        }
    }
}
