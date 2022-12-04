// See https://aka.ms/new-console-template for more information

using BackpackTask;
using System.IO;

Console.WriteLine("Hello, World!");

BackPack_OLD backPack = new BackPack_OLD();
String line;
try
{
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader("C:\\task1.txt");
    //Read the first line of text
    line = sr.ReadLine();
    var stringData = line.Split(" ");
    backPack.maxCapacity = int.Parse(stringData[0]);
    var dataSize = int.Parse(stringData[1]);
    Console.WriteLine($"DataSize: {dataSize}");
    backPack.values = new int[dataSize];
    backPack.weights = new int[dataSize];
    //Continue to read until you reach end of file
    int i = 0;
    while (line != null)
    {
        if (i != 0)
        {
            stringData = line.Split(" ");
            Console.WriteLine($"\nToAddValue {int.Parse(stringData[0])}");
            Console.WriteLine($"\nToAddWeight {int.Parse(stringData[1])}");
            backPack.values[i-1] = int.Parse(stringData[0]);
            backPack.weights[i-1] = int.Parse(stringData[1]);
            Console.WriteLine($"\nAddedValue {backPack.values[i-1]}");
            Console.WriteLine($"\nAddedWeight {backPack.weights[i-1]}");
            Console.WriteLine($"\nI is: {i}");
        }

        //write the line to console window
        //Console.WriteLine(line);
        i++;
        //Read the next line
        line = sr.ReadLine();
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
int backPackData = BackPack_OLD.CountMax(backPack.maxCapacity, backPack.values ,backPack.weights );
Console.WriteLine($"\n{backPackData}");
Console.WriteLine("\nEnd backpack");