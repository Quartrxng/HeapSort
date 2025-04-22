using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    internal class Generator
    {
        private readonly Random _random = new Random();

        public void GenerateTests(int testCount, string folderPath, int size)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            for (int i = 1; i <= testCount; i++)
            {
                int[] array = new int[size];

                for (int j = 0; j < size; j++)
                    array[j] = _random.Next(-10000, 10001);

                File.WriteAllText(Path.Combine(folderPath, $"test_{i}.txt"), string.Join(" ", array));
            }

            Console.WriteLine($"Сгенерировано {testCount} тестов в папке {folderPath}");
        }

        public void GenerateTests(int testCount, string folderPath, int size, int step)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            for (int i = 1; i <= testCount; i++)
            {
                int[] array = new int[size];

                for (int j = 0; j < size; j++)
                    array[j] = _random.Next(-10000, 10001);

                File.WriteAllText(Path.Combine(folderPath, $"test_{i}.txt"), string.Join(" ", array));

                size *= step;
            }

            Console.WriteLine($"Сгенерировано {testCount} тестов в папке {folderPath}");
        }

        public void GenerateTests(int testCount, string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            for (int i = 1; i <= testCount; i++)
            {
                int size = _random.Next(100, 10001);
                int[] array = new int[size];

                for (int j = 0; j < size; j++)
                    array[j] = _random.Next(-10000, 10001);

                File.WriteAllText(Path.Combine(folderPath, $"test_{i}.txt"), string.Join(" ", array));
            }

            Console.WriteLine($"Сгенерировано {testCount} тестов в папке {folderPath}");
        }
    }
}
