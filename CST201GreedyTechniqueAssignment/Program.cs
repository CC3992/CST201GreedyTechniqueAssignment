using CST201GreedyTechniqueAssignment;
//GeeksforGeeks. (2012, March 19). 0/1 Knapsack Problem. GeeksforGeeks. https://www.geeksforgeeks.org/dsa/0-1-knapsack-problem-dp-10/
‌

// Initialize variables
int regularMaximumWeight = 280;
int quantityMaximumWeight = 280;
int dynamicMaximumWeight = 280;

List<Item> items = new List<Item>
{
    new Item { weight = 20, value = 70, quantity = 1 },
    new Item { weight = 30, value = 80, quantity = 2 },
    new Item { weight = 40, value = 90, quantity = 1 },
    new Item { weight = 60, value = 110, quantity = 3 },
    new Item { weight = 70, value = 120, quantity = 1 },
    new Item { weight = 90, value = 200, quantity = 2 }
};
int regularTotalValue = 0;
int quantityTotalValue = 0;
int dynamicTotalValue = 0;  
int regularGreedySteps = 0;
int quantityGreedySteps = 0;
int dynamicGreedySteps = 0;

// Greedy technique

    // Sort the items based on ratio using LINQ
    items = items.OrderByDescending(item => item.Ratio).ToList();

    for (int i = 0; i < items.Count; i++)
    {
        regularGreedySteps++;
        Item item = items[i];
        while (item.weight <= regularMaximumWeight)
        {
        regularGreedySteps++;
            // subtract weight from maximum weight
            regularMaximumWeight = regularMaximumWeight - item.weight;
            //update the total value
            regularTotalValue = regularTotalValue + item.value;
        }
    }
Console.WriteLine("Regular Greedy Technique");
Console.WriteLine("Maximum Value: " + regularTotalValue);
Console.WriteLine("Steps: " + regularGreedySteps);


// Dynamic greedy technique

int[] bestValueAtWeight = new int[dynamicMaximumWeight + 1];

for (int currentWeight = 0; currentWeight <= dynamicMaximumWeight; currentWeight++)
{
    for (int i = 0; i < items.Count; i++)
    {
        Item item = items[i];
        dynamicGreedySteps++;

        if (item.weight <= currentWeight)
        {
            int leftoverWeight = currentWeight - item.weight;

            int possibleValue = bestValueAtWeight[leftoverWeight] + item.value;

            if (possibleValue > bestValueAtWeight[currentWeight])
            {
                bestValueAtWeight[currentWeight] = possibleValue;
            }
        }
    }
}

Console.WriteLine("Dynamic Programming Result");
Console.WriteLine("Maximum Value: " + bestValueAtWeight[dynamicMaximumWeight]);
Console.WriteLine("Steps: " + dynamicGreedySteps);



// Quantity greedy technique

for (int i = 0; i < items.Count; i++)
{
    quantityGreedySteps++;
    Item item = items[i];
    while (item.weight <= quantityMaximumWeight && item.quantity > 0)
    {
        quantityGreedySteps++;
        // subtract weight from maximum weight
        quantityMaximumWeight = quantityMaximumWeight - item.weight;
        //update the total value
        quantityTotalValue = quantityTotalValue + item.value;
        // decrease the quantity
        item.quantity--;    
    }
}
Console.WriteLine("Quantity Greedy Technique");
Console.WriteLine("Maximum Value: " + quantityTotalValue);
Console.WriteLine("Steps: " + quantityGreedySteps);


