using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Оберiть завдання:");
            Console.WriteLine("1. Пошук IP-адрес у форматi d.d.d.d");
            Console.WriteLine("2. Виведiть всi слова заданоi довжини");
            Console.WriteLine("3. Вилучення слiв непарноi довжини");
            Console.WriteLine("4. Вивести на екран усi слова, довжина яких дорiвнює заданому числу");
            Console.WriteLine("5. Текст у кутових дужках замiнити вiдповiдним чином");
            Console.WriteLine("6. Вийти");
            Console.Write("Ваш вибiр: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RunTask1();
                    break;
                case 2:
                    RunTask2();
                    break;
                case 3:
                    RunTask3();
                    break;
                case 4:
                    RunTask4();
                    break;
                case 5:
                    RunTask5();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до меню...");
            Console.ReadKey();
        }
    }

    static void RunTask1()
    {
        string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task1\input.txt");
        string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task1\output.txt");

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Файл не знайдено: {inputFilePath}");
            return;
        }

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

        Console.WriteLine($"Знайдено {matches.Count} IP адрес.");
    }

    static void RunTask2()
    {
        string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task2\input.txt");
        string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task2\output.txt");

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Файл не знайдено: {inputFilePath}");
            return;
        }

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

        Console.WriteLine($"Знайдено {matches.Count} слів довжиною {wordLength}.");
    }

    static void RunTask3()
    {
        string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task3\input.txt");
        string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task3\input.txt");

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Файл не знайдено: {inputFilePath}");
            return;
        }

        string text = File.ReadAllText(inputFilePath);

        string pattern = @"\b\w{1,3}(\w\w)*\b";

        Regex regex = new Regex(pattern);
        string result = regex.Replace(text, "");

        File.WriteAllText(outputFilePath, result);

        Console.WriteLine("Removed all words of odd length.");
    }

    static void RunTask4()
    {
        string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task4\input.txt");
        string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task4\output.txt");

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Файл не знайдено: {inputFilePath}");
            return;
        }

        int wordLength = 7; // Задана довжина слова
        string pattern = @"\b\w{" + wordLength + @"}\b";

        string text = File.ReadAllText(inputFilePath);

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (Match match in matches)
            {
                writer.WriteLine(match.Value);
            }
        }

        Console.WriteLine($"Знайдено {matches.Count} слів довжиною {wordLength}.");
    }

    static void RunTask5()
    {
        string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"D:\2course\CSharpLabs\csharplab8\csharplab8-SheichukOlexandr\txt_files_for_tasks\Task5");
        string dir1 = Path.Combine(baseDir, "Sheychuk1");
        string dir2 = Path.Combine(baseDir, "Sheychuk2");

        Directory.CreateDirectory(dir1);
        Directory.CreateDirectory(dir2);

        string file1Path = Path.Combine(dir1, "t1.txt");
        string file2Path = Path.Combine(dir1, "t2.txt");

        File.WriteAllText(file1Path, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
        File.WriteAllText(file2Path, "<Комар Сергій Федорович, 2000> року народження, місце проживання <м. Київ>");

        string file3Path = Path.Combine(dir2, "t3.txt");

        File.WriteAllText(file3Path, File.ReadAllText(file1Path) + Environment.NewLine + File.ReadAllText(file2Path));

        File.Move(file2Path, Path.Combine(dir2, "t2.txt"));
        File.Copy(file1Path, Path.Combine(dir2, "t1.txt"));

        string allDir = Path.Combine(baseDir, "ALL");
        if (Directory.Exists(allDir))
        {
            Directory.Delete(allDir, true);
        }

        Directory.Move(dir2, allDir);
        Directory.Delete(dir1, true);

        DirectoryInfo directoryInfo = new DirectoryInfo(allDir);
        FileInfo[] files = directoryInfo.GetFiles();

        foreach (FileInfo file in files)
        {
            Console.WriteLine($"File: {file.Name}, Size: {file.Length} bytes, Created: {file.CreationTime}");
        }
    }
}