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
        string preid;
        public Course(string id,string name,double point,string preid = "")
        {
            this.id = id;
            this.name = name;
            this.point = point;
            this.preid = preid;
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
        public string PreId
        {
            get => preid;
        }
        public override string ToString()
        {
            return string.Format("{0,-6}{1,-15}{2,-5}{3,-6}", id, name, point, preid);
        }
    }
}
