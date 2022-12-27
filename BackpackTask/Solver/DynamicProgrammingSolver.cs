using BackpackTask.Utils;

namespace BackpackTask.Solver;

public class DynamicProgrammingSolver : KnapsackSolver
{
    private int[,] table;

    public DynamicProgrammingSolver(IList<Item> items, int capacity)
        : base(items, capacity)
    {
    }

    public override KnapsackSolution Solve()
    {
        FillTable();
        var solution = TakeItems();
        solution.Approach = "Dynamic Programming";

        return solution;
    }

    private KnapsackSolution TakeItems()
    {
        var best = new KnapsackSolution { Items = new List<Item>() };
        for (int row = Items.Count, col = Capacity; row > 0; row--)
            if (table[row, col] != table[row - 1, col])
            {
                best.Items.Add(Items[row - 1]);
                col -= Items[row - 1].Weight;
            }

        best.TotalWeight = GetWeight(best.Items);
        best.Value = GetValue(best.Items);
        return best;
    }

    private void FillTable()
    {
        table = new int[Items.Count + 1, Capacity + 1];
        for (var row = 1; row <= Items.Count; row++)
        {
            var item = Items[row - 1];
            for (var col = 0; col <= Capacity; col++)
                if (item.Weight > col)
                    table[row, col] = table[row - 1, col];
                else
                    table[row, col] = Math.Max(table[row - 1, col], table[row - 1, col - item.Weight] + item.Value);
        }
    }
}