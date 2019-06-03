using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Task4.V3.Db
{
    class ManagerDb
    {
        private readonly Context _ctx;
        public ManagerDb(Context ctx)
        {
            _ctx = ctx;
        }

        public void AddWorker()
        {
            Console.WriteLine("Enter name and surname of new worker:");
            _ctx.Database.EnsureCreated();
            var name = Console.ReadLine();
            var surName = Console.ReadLine();
            _ctx.Workers.Add(new Worker
            {
                Name = name,    
                Surname = surName
            });
            _ctx.SaveChanges();
        }

        public void DeleteWorker()
        {
            Console.WriteLine("Enter id of worker to delete worker:");
            _ctx.Database.EnsureCreated();
            try
            {
                var id = Int32.Parse(Console.ReadLine());
                var worker = _ctx.Workers.First(x => x.Id == id);
                if (worker == null)
                {
                    Console.WriteLine("Nonexistent id");
                    return;
                }
                _ctx.Workers.Remove(worker);
                _ctx.SaveChanges();
                Console.WriteLine("Success");
            }
            catch(FormatException)
            {
                Console.WriteLine("Wrong values");
            }
        }

        public void ShowWorkers()
        {
            Console.WriteLine("A list of all workers:");
            _ctx.Database.EnsureCreated();
            var workers = _ctx.Workers.ToList();
            foreach (var w in workers)
            {
                Console.Write($"> {w.Id}  {w.Name}  {w.Surname}    projects:");
                if (w.Projects == null)
                    continue;
                foreach (var p in w.Projects)
                {
                    if (p != null)
                    {
                        Console.Write($"  {p.Name};");
                    }
                }
                Console.WriteLine();
            }
        }

        public void AddProject()
        {
            Console.WriteLine("Enter name, salary and workers id of new project:");
            _ctx.Database.EnsureCreated();
            try
            {
                var name = Console.ReadLine();
                var salaryString = Console.ReadLine();
                var idString = Console.ReadLine();
                var salary = Int32.Parse(salaryString);
                var id = Int32.Parse(idString);
                _ctx.Projects.Add(new Project
                {
                    Name = name,
                    Salary = salary,
                    WorkerID = id
                });
                _ctx.SaveChanges();
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong values");
            }
            catch(DbUpdateException)
            {
                Console.WriteLine("Nonexistent id");
            }
        }

        public void DeleteProject()
        {
            Console.WriteLine("Enter id of Project to delete Project:");
            _ctx.Database.EnsureCreated();
            try
            {
                var id = Int32.Parse(Console.ReadLine());
                var project =_ctx.Projects.First(x => x.Id == id);
                if (project == null)
                {
                    Console.WriteLine("Nonexistent id");
                    return;
                }
                _ctx.Projects.Remove(project);
                _ctx.SaveChanges();
                Console.WriteLine("Success");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong values");
            }
        }

        public void ShowProjects()
        {
            Console.WriteLine("A list of all projects:");
            _ctx.Database.EnsureCreated();
            var project = _ctx.Projects.ToList();
            foreach (var p in project)
            {
                Console.Write($"> {p.Id}  {p.Name}  {p.Salary}\n");
            }
        }

        public void ShowSortedWorkersList()
        {
            _ctx.Database.EnsureCreated();
            DbSet<Worker> workers =_ctx.Workers;
            var query = workers
                .Select(worker => new
                {
                    worker.Name,
                    worker.Surname,
                    TotalMoney = worker.Projects.Sum(e => e.Salary)
                })
                .OrderByDescending(worker => worker.TotalMoney);

            foreach (var worker in query)
            {
                Console.WriteLine("{0} {1}, total money: {2}", worker.Name, worker.Surname,  worker.TotalMoney);
            }
        }

        public void ChangeProgramsUserID()
        {
            try
            {
                _ctx.Database.EnsureCreated();
                Console.WriteLine("Enter projects id:");
                var pId = Int32.Parse(Console.ReadLine());
                var tmp = _ctx.Projects.First(x => x.Id == pId);
                if(tmp != null)
                {
                    Console.WriteLine("Enter new workers id:");
                    var wId = Int32.Parse(Console.ReadLine());
                    tmp.WorkerID = wId;
                    _ctx.SaveChanges();
                    return;
                }
                Console.WriteLine("Wrong projects id");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong value");
            }
        }

        public void ChangeDistrict()
        {
            Console.WriteLine("Enter id of worker:");
            var wId = Int32.Parse(Console.ReadLine());
            var worker = _ctx.Workers.First(x => x.Id == wId);
            if(worker == null)
            {
                Console.WriteLine("Nonexistent id");
                return;
            }
            Console.WriteLine("Enter new district:");
            var distr = Console.ReadLine();
            worker.District = distr;
            _ctx.SaveChanges();
        }

        public void ChangeHeight()
        {
            Console.WriteLine("Enter id of worker:");
            var wId = Int32.Parse(Console.ReadLine());
            var worker = _ctx.Workers.First(x => x.Id == wId);
            if (worker == null)
            {
                Console.WriteLine("Nonexistent id");
                return;
            }
            Console.WriteLine("Enter new height:");
            var hei = Int32.Parse(Console.ReadLine());
            worker.Height = hei;
            _ctx.SaveChanges();
        }
    }
}
