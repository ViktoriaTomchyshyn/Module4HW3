using System;
using System.Data.SqlTypes;

namespace Module4HW3.DataModel
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public float Rate { get; set; }
        public DateTime StartedDate { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
