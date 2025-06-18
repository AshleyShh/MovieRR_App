using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRR_App.Model
{
    public class AgeRatings
    {

        public int AgeRatingsID { get; set; }
        public string AgeRatingsName { get; set; }

        public AgeRatings(int ageRatingsID, string ageRatingsName)
        {
            AgeRatingsID = ageRatingsID;
            AgeRatingsName = ageRatingsName;
        }

    }
}
