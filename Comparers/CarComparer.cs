using System;
using System.Collections.Generic;
using BernardBawakA7.Models;

namespace BernardBawakA7.Comparers
{
    /// <summary>
    /// This class is like a special rule book for sorting cars
    /// It sorts by Make first, and if two cars have the same Make, it sorts by Price
    /// So all Hondas go together, and within Hondas, the cheapest ones come first
    /// </summary>
    public class CarComparer : IComparer<Car>
    {
        // This method compares two cars and decides which one should come first
        public int Compare(Car? x, Car? y)
        {
            // Handle null cases - if both are null, they're equal
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Step 1: Compare the Make (like comparing "Honda" to "Ford")
            int makeComparison = string.Compare(x.make, y.make, StringComparison.OrdinalIgnoreCase);
            
            // If the Makes are different, we're done - return which Make comes first
            if (makeComparison != 0)
            {
                return makeComparison;
            }

            // Step 2: If we get here, both cars have the same Make
            // Now we need to sort by Price instead (cheaper ones come first)
            return x.price.CompareTo(y.price);
        }
    }
}

