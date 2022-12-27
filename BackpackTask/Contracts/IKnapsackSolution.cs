using BackpackTask.Utils;

namespace BackpackTask.Contracts;

public interface IKnapsackSolution
{
    string Approach { get; set; }

    IList<Item> Items { get; set; }

    int TotalWeight { get; set; }

    int Value { get; set; }
}