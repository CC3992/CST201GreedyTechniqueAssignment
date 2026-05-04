using System;
using System.Collections.Generic;
using System.Text;

namespace CST201GreedyTechniqueAssignment
{
    public class Item
    {
        // Initialize attributes to hold an item's weight, value, and quantity
        public int weight {  get; set; }
        public int value { get; set; }
        public int quantity { get; set; }


        /// <summary>
        /// Calculates the ratio as a double by dividing the value by the weight. 
        /// </summary>
        /// <returns></returns>
        public double Ratio
        {
            get
            {
                return value / weight;
            }
        }
    }
}
