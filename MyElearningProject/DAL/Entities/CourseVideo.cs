using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class CourseVideo
    {
        public int CourseVideoID { get; set; }

        public string Url { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}