using System;
using System.IO;
using System.Text.RegularExpressions;

class Lab8T5
{
    public void Run()
    {
        string inputDir = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task5\Sheychuk";
        string outputDir = @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task5\Sheychuk";

        if (!Directory.Exists(inputDir))
        {
            Directory.CreateDirectory(inputDir);
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Створення файлів та запис даних
        string file1Path = Path.Combine(inputDir, "t1.txt");
        string file2Path = Path.Combine(inputDir, "t2.txt");

        File.WriteAllText(file1Path, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
        File.WriteAllText(file2Path, "<Комар Сергій Федорович, 2000> року народження, місце проживання <м. Київ>");

        string file3Path = Path.Combine(outputDir, "t3.txt");

        File.WriteAllText(file3Path, File.ReadAllText(file1Path) + Environment.NewLine + File.ReadAllText(file2Path));

        // Перенесення та копіювання файлів
        File.Move(file2Path, Path.Combine(outputDir, "t2.txt"));
        File.Copy(file1Path, Path.Combine(outputDir, "t1.txt"));

        Directory.Move(outputDir, Path.Combine(outputDir, "ALL"));
        Directory.Delete(inputDir, true);

        // Виведення повної інформації про файли папки ALL
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(outputDir, "ALL"));
        FileInfo[] files = directoryInfo.GetFiles();

        foreach (FileInfo file in files)
        {
            Console.WriteLine($"File: {file.Name}, Size: {file.Length} bytes, Created: {file.CreationTime}");
        }
    }
}
