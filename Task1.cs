using System;
using System.IO;
using System.Text.RegularExpressions;

class Lab8T1
{
    public void Run()
    {
        string inputFilePath = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task1\input.txt";
        string outputFilePath = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task1\output.txt";
        string text = File.ReadAllText(inputFilePath);

        // Регулярний вираз для пошуку IP-адрес
        string ipPattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";

        Regex regex = new Regex(ipPattern);
        MatchCollection matches = regex.Matches(text);

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (Match match in matches)
            {
                writer.WriteLine(match.Value);
            }
        }

        Console.WriteLine($"Found {matches.Count} IP addresses.");
    }
}
