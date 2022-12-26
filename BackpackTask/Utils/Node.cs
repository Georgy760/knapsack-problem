namespace BackpackTask.Utils;

public class Node : IComparable<Node>
{
    public Node()
    {
        TakenItems = new List<Item>();
    }

    public Node(Node parent)
    {
        Height = parent.Height + 1;
        TakenItems = new List<Item>(parent.TakenItems);
        Bound = parent.Bound;
        Value = parent.Value;
        Weight = parent.Weight;
    }

    public int Height { get; set; }

    public IList<Item> TakenItems { get; set; }

    public int Value { get; set; }

    public int Weight { get; set; }

    public double Bound { get; set; }

    public int CompareTo(Node other)
    {
        return (int)(other.Bound - Bound);
    }

    public void ComputeBound(IList<Item> items, int capacity)
    {
        double w = Weight;
        Bound = Value;
        var index = Height;
        Item currentItem;

        do
        {
            currentItem = items[index];
            if (w + currentItem.Weight > capacity) break;

            w += currentItem.Weight;
            Bound += currentItem.Value;
            index++;
        } while (index < items.Count);

        Bound += (capacity - w) * currentItem.Ratio;
    }
}