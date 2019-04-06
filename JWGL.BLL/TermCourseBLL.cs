﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.DAL;
using JWGL.Model;

namespace JWGL.BLL
{
    public class TermCourseBLL:BaseBLL
    {
        public static TermCourse RetrieveTermCourse(string termCourseId)
        {
            return termCourses.Retrieve(termCourseId);
        }

        public static TermCourse[] GetAllTermCourse()
        {
            return termCourses.RetrieveAll();
        }

        public static string GetCourseDetail(TermCourse tm)
        {
            Course c = courses.Retrieve(tm.CourseID);
            Person t = teachers.Retrieve(tm.TeacherID);
            return string.Format(c.Name + t.Name);
        }
    }
}
