using BackpackTask.Utils;

namespace BackpackTask.Solver;

public class BranchAndBoundSolver : KnapsackSolver
{
    public BranchAndBoundSolver(IList<Item> items, int capacity)
        : base(items, capacity)
    {
    }

    public override KnapsackSolution Solve()
    {
        Items = Items.OrderByDescending(i => i.Ratio).ToList();

        var best = new Node();
        var root = new Node();

        root.ComputeBound(Items, Capacity);

        var queue = new PriorityQueue<Node>();
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var node = queue.Dequeue();

            if (node.Bound > best.Value && node.Height < Items.Count - 1)
            {
                var with = new Node(node);

                var item = Items[node.Height];
                with.Weight += item.Weight;

                if (with.Weight <= Capacity)
                {
                    with.TakenItems.Add(Items[node.Height]);
                    with.Value += item.Value;
                    with.ComputeBound(Items, Capacity);

                    if (with.Value > best.Value) best = with;

                    if (with.Bound > best.Value) queue.Enqueue(with);
                }

                var without = new Node(node);
                without.ComputeBound(Items, Capacity);

                if (without.Bound > best.Value) queue.Enqueue(without);
            }
        }

        var solution = new KnapsackSolution
        {
            Value = best.Value,
            TotalWeight = best.Weight,
            Items = best.TakenItems,
            Approach = "Best-First Search with Branch and Bound"
        };

        return solution;
    }
}