using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Admin:Person
    {
        static int adminID = 1;

        public Admin(string name,string password) : base(name, password){}
               
        public override string GetNewID()
        {
            return string.Format("A00{0}", adminID++);
        }

        public override UserType GetUserType()
        {
            return UserType.Admin;  
        }
    }
}
