using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojtabaStoreCore3.Domain
{
    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
