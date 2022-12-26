namespace BackpackTask.Utils;

public class KnapsackInput
{
    public KnapsackInput()
    {
        Items = new List<Item>();
    }

    public IList<Item> Items { get; set; }

    public int Capacity { get; set; }

    public int ExpectedResult { get; set; }
}