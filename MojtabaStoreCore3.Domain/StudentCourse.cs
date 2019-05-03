using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojtabaStoreCore3.Domain
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
