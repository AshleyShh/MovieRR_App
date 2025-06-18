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
