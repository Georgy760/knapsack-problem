namespace BackpackTask.Utils;

public class Item
{
    public Item()
    {
    }

    public Item(string name, int value, int weight)
    {
        Name = name;
        Value = value;
        Weight = weight;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Added new item:" +
                          $"\nName: {Name}" +
                          $"\nValue: {Value}" +
                          $"\nWeight: {Weight}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public string Name { get; set; }

    public int Value { get; set; }

    public int Weight { get; set; }

    public int Ratio => Value / Weight;

    public override string ToString()
    {
        return string.Format("\n    {0} - weight: {1}, value: {2}", Name, Weight, Value);
    }
}