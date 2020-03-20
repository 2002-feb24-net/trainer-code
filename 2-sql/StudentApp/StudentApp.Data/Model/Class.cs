using System;
using System.Collections.Generic;

namespace StudentApp.Data.Model
{
    public partial class Class
    {
        public Class()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string CourseNumber { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
