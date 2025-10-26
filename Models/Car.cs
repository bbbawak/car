using System;

namespace BernardBawakA7.Models
{
    /// <summary>
    /// This class represents a single car from our JSON file
    /// It's basically a blue print for creating car objects
    /// </summary>
    public class Car : IComparable<Car>
    {
        // These are all the properties a car has - Make, Model, Year, etc.
        public string make { get; set; } = string.Empty;           // Like "Ford" or "Honda"
        public string model { get; set; } = string.Empty;          // Like "Focus" or "Accord"
        public int year { get; set; }                              // The year the car was made
        public decimal price { get; set; }                          // How much the car costs
        public string color { get; set; } = string.Empty;          // The color of the car
        public int cylinders { get; set; }                         // Engine cylinder count
        public int mileage { get; set; }                           // How many miles on the car

        // This method tells the program how to display a car in the list
        public override string ToString()
        {
            return $"Make: {make}, Model: {model}, Price: {price}, Mileage: {mileage}, Color: {color}";
        }

        /// <summary>
        /// This method lets the car sort itself by Make automatically
        /// When we call _cars.Sort(), it uses this to figure out which car comes first
        /// </summary>
        public int CompareTo(Car? other)
        {
            // Safety check - if we're comparing to nothing, just say we're bigger
            if (other == null) return 1;
            
            // Compare the Make alphabetically (A comes before Z)
            // OrdinalIgnoreCase means "A" and "a" are treated the same
            return string.Compare(make, other.make, StringComparison.OrdinalIgnoreCase);
        }
    }
}

