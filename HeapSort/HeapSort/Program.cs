namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string testsFolder = "tests";

            const string reusltFolder = "result";

            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "information.txt")))
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "information.txt"), DateTime.Now.ToString() + "\n");
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "information.txt"), "№  Элементов\tВремя(мс)     Итерации     Проверка сортировки" + "\n");
            }

            // new Generator().GenerateTests(10, testsFolder, 1, 10);

            new Generator().GenerateTests(3,testsFolder,5); 

            new Tester().TestSorting(testsFolder, reusltFolder);
        }
    }
}
