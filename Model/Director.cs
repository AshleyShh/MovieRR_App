using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRR_App.Model
{
    public class Director
    {

        public int DirectorID { get; set; }
        public string DirectorName { get; set; }

        public Director(int directorID, string directorName) 
        {
            DirectorID = directorID;
            DirectorName = directorName;
        }   

    }
}
