using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public abstract class Person
    {
        string id,name,password;

        public Person(string name,string password)
        {
            this.name = name;
            this.password = password;
            id = GetNewID();
        }
        
        public string ID
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public virtual UserType GetUserType()
        {
            return UserType.Unauthorized;
        }
        public abstract string GetNewID();
    }
    public enum UserType
    {
        Unauthorized, Authorized, Admin, Teacher, Student
    };
}
