namespace 排序算法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 9, 8, 5, 6, 4, 2, 3, 1, 7, 0 };
            //BubbleSort(values);
            //SelectionSort(values);
            //InsertionSort(values);
            //ShellSort(values);
            //QuickSort(values);
            BinSortSort(values);
        }

        public static void BubbleSort(int[] values)
        {
            int length = values.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (values[j] > values[j + 1])
                    {
                        int temp = values[j + 1];
                        values[j + 1] = values[j];
                        values[j] = temp;
                    }
                }
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");
            }
        }

        public static void SelectionSort(int[] values)
        {
            int length = values.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (values[i] > values[j])
                    {
                        int temp = values[i];
                        values[i] = values[j];
                        values[j] = temp;
                    }
                }
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");
            }
        }

        public static void InsertionSort(int[] values)
        {
            int length = values.Length;
            for (int i = 0; i < length - 1; i++)
            {
                int j = i;
                int temp = values[i];
                while (j > 0 && values[j - 1] > temp)
                {
                    values[j] = values[j - 1];
                    j--;
                }
                values[j] = temp;
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");
            }
        }

        public static void ShellSort(int[] values)
        {
            int length = values.Length;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < length; i++)
                {
                    int j = i;
                    int temp = values[i];
                    while (j >= gap && values[j - gap] > temp)
                    {
                        values[j] = values[j - gap];
                        j -= gap;
                    }
                    values[j] = temp;
                }
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");
            }
        }

        public static void QuickSort(int[] values)
        {
            void QuickSort(int[] values, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex)
                {
                    int length = values.Length;
                    for (int i = 0; i < length; i++)
                    {
                        Console.Write($"{values[i]} ");
                    }
                    Console.WriteLine($" ");
                    return;
                }

                int lIndex = minIndex;
                int rIndex = maxIndex;
                int key = values[minIndex];

                while (lIndex < rIndex)
                {
                    while (lIndex < rIndex && values[rIndex] >= key)
                    {
                        rIndex--;
                    }

                    if (lIndex < rIndex)
                    {
                        values[lIndex] = values[rIndex];
                        lIndex++;
                    }

                    while (lIndex < rIndex && values[lIndex] < key)
                    {
                        lIndex++;
                    }

                    if (lIndex < rIndex)
                    {
                        values[rIndex] = values[lIndex];
                        rIndex--;
                    }
                }

                values[lIndex] = key;

                QuickSort(values, minIndex, lIndex - 1);
                QuickSort(values, lIndex + 1, maxIndex);
            }
            int minIndex = 0;
            int maxIndex = values.Length - 1;
            QuickSort(values, minIndex, maxIndex);
        }

        public static void BinSortSort(int[] values)
        {
            int max = 0;
            int index = -1;
            int length = values.Length;

            for (int i = 0; i < length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }
            }

            int[] binArry = new int[max + 1];

            for (int i = 0; i < max + 1; i++)
            {
                binArry[i] = -1000;
            }

            for (int i = 0; i < length; i++)
            {
                binArry[values[i]] = values[i];
            }

            for (int i = 0; i < binArry.Length; i++)
            {
                if (binArry[i] != -1000)
                {
                    values[++index] = binArry[i];
                }
            }

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{values[i]} ");
            }
            Console.WriteLine($" ");
        }
    }
}
