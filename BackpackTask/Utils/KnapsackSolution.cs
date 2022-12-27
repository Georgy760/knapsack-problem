using System.Text;
using BackpackTask.Contracts;

namespace BackpackTask.Utils;

public class KnapsackSolution : IKnapsackSolution
{
    public string Approach { get; set; }

    public IList<Item> Items { get; set; }

    public int TotalWeight { get; set; }

    public int Value { get; set; }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine(string.Format("{0} | value: {1}, total weight: {2}", Approach, Value, TotalWeight));
        output.AppendLine(" Products:" + string.Join(", ", Items));

        return output.ToString();
    }
}