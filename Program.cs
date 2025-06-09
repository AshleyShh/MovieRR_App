using MovieRR_App.Repositories;
using MovieRR_App.View;

namespace MovieRR_App
{
    internal class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager (connectionString);

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView ();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1";
                    { 
                        List<Director> director = storageManager.GetAllDirectors ();
                        view.DisplayDirector(director);
                    }
                    break
                        case "2":
                    UpdateDirectorName();
                    break;
                    case "3":
                    InsertNewDirector();
                    break;
                    case "4":
                    DeleteDirectorByName();
                    break;
                /*case "5":
                 exit = true;
                break; */
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;

            }
            storageManager.CloseConnection ();
            
        }
    }
}
