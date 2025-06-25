using MovieRR_App.Repositories;
using MovieRR_App.View;
using System.Runtime.InteropServices;

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
            storageManager = new StorageManager(connectionString);

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<Directors> director = storageManager.GetAllDirectors();
                        view.DisplayDirector(directors);
                    }
                    break;
                case "2":
                    UpdateDirectorName();
                    break;
                case "3":
                    InsertNewDirectors();
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
            storageManager.CloseConnection();
        }


            private static void UpdateDirectorName()
            { 
                view.DisplayMessage("Enter the directorid to update:    ");
                int directorId = view.GetIntInput();
                view.DisplayMessage("Enter the new director name:   ");
                string directorName = view.GetInput();
                int rowsAffected = storageManager.UpdateDirectorName(directorId, directorName);
                view.DisplayMessage($"Rows affected: {rowsAffected}");
            }

            /* private static void InsertNewDirector()
             {
            view.DisplayMessage("Enter the new director name:  *);
            string directorName = view.GetInput();
            int generateId = strongeManager.InsertDirector
            view.DisplayMessage($"New group insert

            }*/

            private static void InsertNewDirectors()
            {
                view.DisplayMessage("Enter the new director name:  ");
                string directorName = view.GetInput();
                int directorID = 0;
                Director directors1 = new Director(directorID, directorName);
                int generateID = storageManager.InsertNewDirectors(directors1);
                view.DisplayMessage($"New director inserted with ID: {generateID}");
            }

            private static void DeleteDirectorByName()
            {
                view.DisplayMessage("Enter the director name to delete:   ");
                string directorName = view.GetInput();
                int rowsAffected = storageManager.DeleteDirectorByName(directorName);
                view.DisplayMessage($"Rows affected: {rowsAffected}");
            }

    
        }
    }

