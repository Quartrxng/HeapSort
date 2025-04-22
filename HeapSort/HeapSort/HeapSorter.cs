using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    internal class HeapSorter
    {
        public long IterationCount { get; private set; }

        public void Sort(int[] array)
        {
            IterationCount = 0;
            int n = array.Length;

            // Построение кучи
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            // Извлекаем элементы из кучи
            for (int i = n - 1; i > 0; i--)
            {
                // Перемещаем корень в конец
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int size, int rootIndex)
        {
            IterationCount++;

            while (true)
            {
                int largest = rootIndex;
                int left = 2 * rootIndex + 1;
                int right = 2 * rootIndex + 2;

                if (left < size && array[left] > array[largest])
                    largest = left;

                if (right < size && array[right] > array[largest])
                    largest = right;

                if (largest != rootIndex)
                {
                    (array[rootIndex], array[largest]) = (array[largest], array[rootIndex]);
                    rootIndex = largest;
                    IterationCount++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
