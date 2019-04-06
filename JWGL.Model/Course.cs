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
        string id;
        string name;
        double point;
        public Course(string id,string name,double point)
        {
            this.id = id;
            this.name = name;
            this.point = point;
        }
        public string ID
        {
            get => id;
        }
        public string Name
        {
            get => name;
        }

        public double Point
        {
            get => point;
            set => point = value;
        }
    }
}
