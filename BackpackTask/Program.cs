using System.Diagnostics;
using BackpackTask.Solver;
using BackpackTask.Utils;

namespace BackpackTask;

public class EntryPoint
{
    public enum METHOD
    {
        DYNAMIC_PROGRAMMING,
        BRANCH_AND_BOUND
    }

    private static readonly string path0 = @"./../../../SampleInputs/problem16.7test.txt"; //Both methods
    private static readonly string path1 = @"./../../../SampleInputs/problem16.7.txt"; //Only branch&bound

    public static void Main()
    {
        var input0 = AddData(path0);
        var input1 = AddData(path1);

        PrintResults(input0, METHOD.DYNAMIC_PROGRAMMING);
        PrintResults(input0, METHOD.BRANCH_AND_BOUND);
        //PrintResults(input1, METHOD.DYNAMIC_PROGRAMMING);
        PrintResults(input1, METHOD.BRANCH_AND_BOUND);
    }

    public static void PrintResults(KnapsackInput input, METHOD method)
    {
        KnapsackSolver solver = null;
        switch (method)
        {
            case METHOD.BRANCH_AND_BOUND:
                solver = new BranchAndBoundSolver(input.Items, input.Capacity);
                break;
            case METHOD.DYNAMIC_PROGRAMMING:
                solver = new DynamicProgrammingSolver(input.Items, input.Capacity);
                break;
        }


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Max Capacity is {0}", input.Capacity);
        Console.ForegroundColor = ConsoleColor.Black;
        var sw = new Stopwatch();

        sw.Start();

        var solution = solver?.Solve();

        sw.Stop();

        Console.WriteLine(solution);
        Console.WriteLine("Elapsed = {0}\n", sw.Elapsed);
    }

    public static KnapsackInput AddData(string path)
    {
        string line;
        var sr = new StreamReader(path);
        line = sr.ReadLine();

        var stringData = line.Split(" ");

        var dataSize = int.Parse(stringData[1]);
        Console.WriteLine($"DataSize: {dataSize}");

        var maxCapacity = int.Parse(stringData[0]);
        Console.WriteLine($"MaxCapacity: {maxCapacity}\n");

        line = sr.ReadLine();

        var i = 0;
        var items = new List<Item>();
        while (line != null || i > dataSize)
        {
            stringData = line.Split(" ");
            var item = new Item(i.ToString(), int.Parse(stringData[0]), int.Parse(stringData[1]));
            items.Add(item);
            //Console.WriteLine($"\nI is: {i}\n");
            
            i++;
            line = sr.ReadLine();
        }

        sr.Close();


        var input = new KnapsackInput
        {
            Capacity = maxCapacity,
            Items = items
        };

        return input;
    }
}