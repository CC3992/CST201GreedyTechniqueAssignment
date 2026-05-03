using CST201GreedyTechniqueAssignment;
//GeeksforGeeks. (2012, March 19). 0/1 Knapsack Problem. GeeksforGeeks. https://www.geeksforgeeks.org/dsa/0-1-knapsack-problem-dp-10/
‌

// Initialize variables
int regularMaximumWeight = 280;
int quantityMaximumWeight = 280;
int dynamicMaximumWeight = 280;
// Create a new list of items with the preset weight, value, and quantity.
List<Item> items = new List<Item>
{
    new Item { weight = 20, value = 70, quantity = 1 },
    new Item { weight = 30, value = 80, quantity = 2 },
    new Item { weight = 40, value = 90, quantity = 1 },
    new Item { weight = 60, value = 110, quantity = 3 },
    new Item { weight = 70, value = 120, quantity = 1 },
    new Item { weight = 90, value = 200, quantity = 2 }
};
// Initialize total value and steps for each technique
int regularTotalValue = 0;
int quantityTotalValue = 0;
int dynamicTotalValue = 0;  
int regularGreedySteps = 0;
int quantityGreedySteps = 0;
int dynamicGreedySteps = 0;

// Regular Greedy technique

    // Sort the items based on ratio using LINQ
    items = items.OrderByDescending(item => item.Ratio).ToList();
//iterate through the items and add them to the knapsack until the maximum weight is reached
for (int i = 0; i < items.Count; i++)
    {
    // Increment the step counter for each iteration
        regularGreedySteps++;
    // Create a new item to hold the current item in the loop
    Item item = items[i];
    //While the weight of the item is less than or equal to the maximum weight, add the item to the knapsack
    while (item.weight <= regularMaximumWeight)
        {
        // Increment the step counter for each iteration
        regularGreedySteps++;
            // subtract weight from maximum weight
            regularMaximumWeight = regularMaximumWeight - item.weight;
            //update the total value
            regularTotalValue = regularTotalValue + item.value;
        }
    }
// Print the info
Console.WriteLine("Regular Greedy Technique");
Console.WriteLine("Maximum Value: " + regularTotalValue);
Console.WriteLine("Steps: " + regularGreedySteps);


// Dynamic greedy technique
// Create an array to hold the best value at each weight
int[] bestValueAtWeight = new int[dynamicMaximumWeight + 1];
// Iterate through each weight from 0 to the maximum weight
for (int currentWeight = 0; currentWeight <= dynamicMaximumWeight; currentWeight++)
{
    // Iterate through each item in the list
    for (int i = 0; i < items.Count; i++)
    {
        // Create a temporary item to hold the current item in the loop
        Item item = items[i];
        // Increment the step counter for each iteration
        dynamicGreedySteps++;
        // If the weight of the item is less than or equal to the current weight
        if (item.weight <= currentWeight)
        {
            // assign leftover weight to the current weight minus the weight of the item
            int leftoverWeight = currentWeight - item.weight;
            // assign possibleValue to the best value at the leftover weight plus the value of the item
            int possibleValue = bestValueAtWeight[leftoverWeight] + item.value;
            // If the possible value is greater than the best value at the current weight, update the best value at the current weight
            if (possibleValue > bestValueAtWeight[currentWeight])
            {
                bestValueAtWeight[currentWeight] = possibleValue;
            }
        }
    }
}
// Print the info
Console.WriteLine("Dynamic Programming Result");
Console.WriteLine("Maximum Value: " + bestValueAtWeight[dynamicMaximumWeight]);
Console.WriteLine("Steps: " + dynamicGreedySteps);



// Quantity greedy technique
// Iterate through each item in the list.
for (int i = 0; i < items.Count; i++)
{
    // Increment the step counter for each iteration
    quantityGreedySteps++;
    // Create a new item to hold the current item in the loop
    Item item = items[i];
    // While the weight of the item is less than or equal to the maximum weight and the quantitiy of the item is greater than 0.
    while (item.weight <= quantityMaximumWeight && item.quantity > 0)
    {
        // Increment the step counter for each iteration
        quantityGreedySteps++;
        // subtract weight from maximum weight
        quantityMaximumWeight = quantityMaximumWeight - item.weight;
        //update the total value
        quantityTotalValue = quantityTotalValue + item.value;
        // decrease the quantity
        item.quantity--;    
    }
}
// Print the info
Console.WriteLine("Quantity Greedy Technique");
Console.WriteLine("Maximum Value: " + quantityTotalValue);
Console.WriteLine("Steps: " + quantityGreedySteps);


