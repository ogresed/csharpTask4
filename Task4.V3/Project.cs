using System;
using System.Collections.Generic;
using System.Text;

namespace Task4.V3
{
    class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Worker Worker { get; set; }
        public int WorkerID { get; set; }
    }
}
