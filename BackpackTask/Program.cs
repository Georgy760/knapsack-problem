// See https://aka.ms/new-console-template for more information

using BackpackTask;
using System.IO;
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

Console.WriteLine("\nEnd backpack");