using System;
using System.Collections.Generic;
using System.Text;

namespace Task4.V3
{
    class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
