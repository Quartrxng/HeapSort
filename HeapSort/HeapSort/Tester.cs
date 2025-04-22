using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    internal class Tester
    {
        public void TestSorting(string testsFolder, string resultsFolder)
        {
            var sorter = new HeapSorter();
            string? informationFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "information.txt");
            // Создаем папку для результатов
            Directory.CreateDirectory(resultsFolder);

            Console.WriteLine("№  Элементов\tВремя(мс)     Итерации     Проверка сортировки");
            int testNumber = 1;
            foreach (string testFile in Directory.GetFiles(testsFolder))
            {
                // Чтение данных
                int[] numbers = ReadTestFile(testFile);
                int[] testArray = (int[])numbers.Clone();

                // Замер времени
                var timer = Stopwatch.StartNew();
                sorter.Sort(testArray);
                timer.Stop();

                // Проверка правильности сортировки
                bool isSorted = IsArraySorted(testArray);

                // Сохранение результата
                string resultFile = Path.Combine(resultsFolder, $"result_{testNumber}.txt");
                File.WriteAllText(resultFile, string.Join(" ", testArray));

                string information = $"{testNumber}\t{numbers.Length}\t{timer.Elapsed.TotalMilliseconds:F2}\t{sorter.IterationCount}\t{(isSorted)}";

                // Вывод информации
                Console.WriteLine(information);
                File.AppendAllText(informationFilePath, information + "\n");

                testNumber++;
            }
        }

        private int[] ReadTestFile(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return Array.ConvertAll(text.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private bool IsArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    return false;
            return true;
        }
    }
}
