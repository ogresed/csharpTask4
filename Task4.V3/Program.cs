using System;

namespace Task4.V3
{
    class Program
    {
        private static readonly string HELP = 
                    "Commands: \n" +
                    "help - to show  this text\n" +
                    "clear - clear screen\n" +
                    "aw - add worker\n" +
                    "dw - delete worker\n" +
                    "sw - show all workers\n" +
                    "sswl - show sorted workers list\n" +
                    "ap - add project\n" +
                    "dp - delete project\n" +
                    "sp - show projects\n" +
                    "cpu - change userID in project\n" +
                    "exit - exit app\n";
        static void Main(string[] args)
        {
            using (var ctx = new Context())
            {
                ManagerDb manager = new ManagerDb(ctx);
                Console.Write(HELP);
                bool work = true;
                while(work)
                {
                    var command = Console.ReadLine();
                    switch(command)
                    {
                        case "aw":
                            manager.AddWorker();
                            break;
                        case "sswl":
                            manager.ShowSortedWorkersList();
                            break;
                        case "ap":
                            manager.AddProject();
                            break;
                        case "exit":
                            work = false;
                            break;
                        case "sw":
                            manager.ShowWorkers();
                            break;
                        case "dw":
                            manager.DeleteWorker();
                            break;
                        case "help":
                            Console.Write(HELP);
                            break;
                        case "dp":
                            manager.DeleteProject();
                            break;
                        case "sp":
                            manager.ShowProjects();
                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "cpu":
                            manager.ChangeProgramsUserID();
                            break;
                        case "9":

                            break;
                        default:
                            Console.WriteLine("Unknow command");
                            break;
                    }
                    Console.Write(":");
                }
            }
            Console.WriteLine("Enter some key to continue");
            Console.ReadKey();
        }
    }
}
