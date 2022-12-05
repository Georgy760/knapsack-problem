// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Knapsack;
using Knapsack.Solvers;
using Knapsack.Utils;
/*
String line;
try
{
    
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader("C:\\C_Projects\\Backpack\\BackpackTask\\task1.txt");
    //Read the first line of text
    line = sr.ReadLine();
    var stringData = line.Split(" ");
    var dataSize = int.Parse(stringData[1]);
    Console.WriteLine($"DataSize: {dataSize}");
    var maxCapacity = int.Parse(stringData[0]);
    Backpack backpack = new Backpack(maxCapacity);
    
    //Continue to read until you reach end of file
    int i = 0;
    line = sr.ReadLine();
    List<Item> items = new List<Item>();
    while (line != null || i > dataSize)
    {
        stringData = line.Split(" ");
        Item item = new Item(i.ToString(), double.Parse(stringData[1]), double.Parse(stringData[0]));
        items.Add(item);
        Console.WriteLine($"\nI is: {i}\n");
        

        //write the line to console window
        //Console.WriteLine(line);
        i++;
        //Read the next line
        line = sr.ReadLine();
    }
    //close the file
    sr.Close();
    backpack.MakeAllSets(items);
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Executing finally block.");
}
Console.WriteLine("\nStart backpack");

Console.WriteLine("\nEnd backpack");*/
public class EntryPoint
{
    public static void Main()
    {
        /* var input1 = ReadInput("./../../SampleInputs/easy20.txt");
         PrintResults(input1);*/
        var input2 = new KnapsackInput()
        {
            Capacity = 18,
            ExpectedResult = 44,
            Items =
                new List<Item>()
                {
                    new Item { Name = "fourth", Weight = 4, Value = 12 },
                    new Item { Name = "third", Weight = 6, Value = 10 },
                    new Item { Name = "second", Weight = 5, Value = 8 },
                    new Item { Name = "cheese", Weight = 7, Value = 11 },
                    new Item { Name = "first", Weight = 3, Value = 14 },
                    new Item { Name = "potatos", Weight = 1, Value = 7 },
                    new Item { Name = "bear", Weight = 6, Value = 9 }
                }
        };
        PrintResults(input2);

        var input3 = new KnapsackInput()
        {
            Capacity = 4,
            ExpectedResult = 6,
            Items = new List<Item>()
            {
                new Item() { Name = "first", Value = 2, Weight = 1 },
                new Item() { Name = "Second", Value = 3, Weight = 2 },
                new Item() { Name = "Third", Value = 4, Weight = 3 },
                new Item() { Name = "Fourth", Value = 5, Weight = 4 },
                new Item() { Name = "Second", Value = 6, Weight = 5 }
            }
        };
        PrintResults(input3);

        var input4 = new KnapsackInput()
        {
            Capacity = 16,
            ExpectedResult = 90,
            Items = new List<Item>()
            {
                new Item { Name = "1", Value = 40, Weight = 2 },
                new Item { Name = "2", Value = 30, Weight = 5 },
                new Item { Name = "3", Value = 50, Weight = 10 },
                new Item { Name = "4", Value = 10, Weight = 5 }
            }
        };
        
        
        PrintResults(input4);
    }

    public static void PrintResults(KnapsackInput input)
    {
        IList<KnapsackSolver> solvers = new List<KnapsackSolver>()
        {
            new DynamicProgrammingSolver(input.Items, input.Capacity)
        };

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Max Capacity is {0}", input.Capacity);
        Console.WriteLine("Expected result is {0}", input.ExpectedResult);
        Console.ForegroundColor = ConsoleColor.White;
        foreach (var solver in solvers)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            var solution = solver.Solve();

            sw.Stop();

            Console.WriteLine(solution);
            Console.WriteLine("Elapsed = {0}\n", sw.Elapsed);
        }
    }
}
