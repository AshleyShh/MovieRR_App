using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRR_App.Model
{
    public class Ratings
    {

            public int RatingsID { get; set; }
            public int RatingsName { get; set; }

            public Ratings(int ratingsID, int ratingsName)
            {
                RatingsID = ratingsID;
                RatingsName = ratingsName;
            }

    }
 }


