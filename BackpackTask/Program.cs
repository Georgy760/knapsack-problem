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
    var maxCapacity = int.Parse(stringData[0]);
    var dataSize = int.Parse(stringData[1]);
    Console.WriteLine($"DataSize: {dataSize}\n");
    //Continue to read until you reach end of file
    int i = 0;
    List<Item> items = new List<Item>();
    while (line != null)
    {
        if (i != 0)
        {
            
            stringData = line.Split(" ");
            //Console.WriteLine($"\nToAddValue {int.Parse(stringData[0])}");
            //Console.WriteLine($"\nToAddWeight {int.Parse(stringData[1])}");
            Item item = new Item(i.ToString(), double.Parse(stringData[1]), double.Parse(stringData[0]));
            items.Add(item);
            Console.WriteLine($"\nI is: {i}\n");
        }

        //write the line to console window
        //Console.WriteLine(line);
        i++;
        //Read the next line
        line = sr.ReadLine();
    }

    while (line != null)
    {
        if (i != 0)
        {
            
            line = sr.ReadLine();
        }
    }
    //close the file
    
    sr.Close();
    //Console.ReadLine();
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
//int backPackData = BackPack_OLD.CountMax(backPack.maxCapacity, backPack.values ,backPack.weights );
//Console.WriteLine($"\n{backPackData}");
Console.WriteLine("\nEnd backpack");