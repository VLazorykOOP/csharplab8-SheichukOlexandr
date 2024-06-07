using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Lab8T2
{
    public void Run()
    {
        string inputFilePath = @"D:\2course\CSharpLabs\csharplab8\csharplab8 - SheichukOlexandr\txt_files_for_tasks\Task2\input.txt";
        string outputFilePath = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task2\output.txt";
        string text = File.ReadAllText(inputFilePath);

        int wordLength = 5; // Задана довжина слова
        string pattern = @"\b\w{" + wordLength + @"}\b";

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (Match match in matches)
            {
                writer.WriteLine(match.Value);
            }
        }

        Console.WriteLine($"Found {matches.Count} words of length {wordLength}.");
    }
}
