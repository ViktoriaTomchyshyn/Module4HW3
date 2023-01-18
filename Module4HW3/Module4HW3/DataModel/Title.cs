using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Module4HW3.DataModel
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
