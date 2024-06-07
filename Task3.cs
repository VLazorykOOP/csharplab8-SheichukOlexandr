using System;
using System.IO;
using System.Text.RegularExpressions;

class Lab8T3
{
    public void Run()
    {
        string inputFilePath = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task3\input.txt";
        string outputFilePath = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task3\output.txt";
        string text = File.ReadAllText(inputFilePath);

        string pattern = @"\b\w{1,3}(\w\w)*\b";

        Regex regex = new Regex(pattern);
        string result = regex.Replace(text, "");

        File.WriteAllText(outputFilePath, result);

        Console.WriteLine("Removed all words of odd length.");
    }
}
