
using CST201GreedyTechniqueAssignment;

// Initialize variables
int maximumWeight = 280;
List<Item> items = new List<Item>
{
    new Item { weight = 20, value = 70, quantity = 1 },
    new Item { weight = 30, value = 80, quantity = 2 },
    new Item { weight = 40, value = 90, quantity = 1 },
    new Item { weight = 60, value = 110, quantity = 3 },
    new Item { weight = 70, value = 120, quantity = 1 },
    new Item { weight = 90, value = 200, quantity = 2 }
};
int totalValue = 0;
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
        while (item.weight <= maximumWeight)
        {
        regularGreedySteps++;
            // subtract weight from maximum weight
            maximumWeight = maximumWeight - item.weight;
            //update the total value
            totalValue = totalValue + item.value;
        }
    }
Console.WriteLine("Regular Greedy Technique");
Console.WriteLine("Maximum Value: " + totalValue);
Console.WriteLine("Steps: " + dynamicGreedySteps);


// Dynamic greedy technique

int[] bestValueAtWeight = new int[maximumWeight + 1];

for (int currentWeight = 0; currentWeight <= maximumWeight; currentWeight++)
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
Console.WriteLine("Maximum Value: " + bestValueAtWeight[maximumWeight]);
Console.WriteLine("Steps: " + dynamicGreedySteps);


