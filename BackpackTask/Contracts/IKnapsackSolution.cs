using BackpackTask.Utils;

namespace BackpackTask.Contracts;

public interface IKnapsackSolution
{
    string Approach { get; set; }

    IList<Item> Items { get; set; }

    double TotalWeight { get; set; }

    double Value { get; set; }
}