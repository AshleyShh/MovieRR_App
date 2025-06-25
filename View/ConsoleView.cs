using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRR_App.Model;

namespace MovieRR_App.View
{
    public class ConsoleView
    {

        public int LoginMenu()
        {
            int choice;
            Console.WriteLine("Welcome to my Movie Website! ");
            do
            {
                Console.WriteLine("LOGIN HERE:");
                Console.WriteLine("1. User Login");
                Console.WriteLine("2. User Registration");
                Console.WriteLine("3. Admin Login");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Select an option: ");
                choice = int.Parse(Console.ReadLine());
                if ((choice < 0) || (choice > 4))
                    Console.WriteLine("Invalid input. Please enter your choice again.");
            } while ((choice < 1) || (choice > 4));
            return choice;
        }
        public string DisplayMenu()
        {
            Console.WriteLine("Welcome to my Movie Rating programe! ");
            Console.WriteLine("Menu  ");
            Console.WriteLine("1.  View all records");
            Console.WriteLine("2.  Update a Director's name by directorID  ");
            Console.WriteLine("3.  Insert a new Director name  ");
            Console.WriteLine("4.  Delete a Director by director_name    ");
            return Console.ReadLine();
        }

         
        public void DisplayDirector(List<Director> directors)
        {
            foreach (Director director in directors)
            {
                Console.WriteLine($"{director.DirectorID}, {director.DirectorName}");
            }
        }
        public void DisplayMessage (string message)
        { 
            Console.WriteLine(message); 
        }
        public string GetInput()
        {
            return Console.ReadLine();

        }
        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }



    }
}
