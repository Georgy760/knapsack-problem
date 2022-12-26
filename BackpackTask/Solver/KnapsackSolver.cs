using BackpackTask.Utils;

namespace BackpackTask.Solver;

public abstract class KnapsackSolver
{
    protected KnapsackSolver(IList<Item> items, int capacity)
    {
        Items = items;
        Capacity = capacity;
    }

    protected IList<Item> Items { get; set; }

    protected int Capacity { get; set; }

    public abstract KnapsackSolution Solve();

    public double GetWeight(IList<Item> items)
    {
        return items.Sum(i => i.Weight);
    }

    public double GetValue(IList<Item> items)
    {
        return items.Sum(i => i.Value);
    }
}