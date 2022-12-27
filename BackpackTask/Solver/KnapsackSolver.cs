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

    public int GetWeight(IList<Item> items)
    {
        return items.Sum(i => i.Weight);
    }

    public int GetValue(IList<Item> items)
    {
        return items.Sum(i => i.Value);
    }
}