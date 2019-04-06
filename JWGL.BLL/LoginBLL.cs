using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;
namespace JWGL.BLL
{
    public class LoginBLL : BaseBLL
    {
        public static bool Login(string id, string pass, out string err)
        {
            err = "";
            Person p = null;
            switch ((id.ToUpper())[0])
            {
                case 'A':
                    p = admins.Retrieve(id);
                    break;
                case 'T':
                    p = teachers.Retrieve(id);
                    break;
                case 'S':
                    p = students.Retrieve(id);
                    break;
                default:
                    err = "编号不规范";
                    return false;
            }
            if (p == null)
            {
                err = "查无此人"; return false;
            }
            if (p.Password == pass)
            {
                user = p;
                return true;
            }
            else
            {
                err = "密码错误";
                return false;
            }
        }
    }
}
