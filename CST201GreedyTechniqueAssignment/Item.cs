using System;
using System.Collections.Generic;
using System.Text;

namespace CST201GreedyTechniqueAssignment
{
    public class Item
    {
        public int weight {  get; set; }
        public int value { get; set; }
        public int quantity { get; set; }


        /// <summary>
        /// Calculates the ratio as a double. 
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
