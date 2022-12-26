using Wintellect.PowerCollections;

namespace BackpackTask.Utils;

public class PriorityQueue<T> where T : IComparable<T>
{
    private readonly OrderedBag<T> queue;

    public PriorityQueue()
    {
        queue = new OrderedBag<T>();
    }

    public int Count => queue.Count;

    public void Enqueue(T element)
    {
        queue.Add(element);
    }

    public T Dequeue()
    {
        return queue.RemoveFirst();
    }
}