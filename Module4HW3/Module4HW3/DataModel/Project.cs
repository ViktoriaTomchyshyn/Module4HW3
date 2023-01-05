using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Module4HW3.DataModel
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public float Budjet { get; set; }
        public DateTime StartedDate { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
