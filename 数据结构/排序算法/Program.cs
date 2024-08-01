namespace 排序算法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 9, -18, 25, 36, 144, 52, 63, 71, 87, 90 };
            //BubbleSort(values);
            //SelectionSort(values);
            //InsertionSort(values);
            //ShellSort(values);
            //QuickSort(values);
            //HeapSort(values);
            //MergeSort(values);
            RadixSort(values);
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

        public static void HeapSort(int[] values)
        {
            void Heapify(int[] values, int length, int i)
            {
                int largest = i;
                int leftChild = 2 * i + 1;
                int rightChild = 2 * i + 2;

                if (leftChild < length && values[largest] < values[leftChild])
                {
                    largest = leftChild;
                }

                if (rightChild < length && values[largest] < values[rightChild])
                {
                    largest = rightChild;
                }

                if (largest != i)
                {
                    int temp = values[largest];
                    values[largest] = values[i];
                    values[i] = temp;

                    Heapify(values, length, largest);
                }
            }

            int length = values.Length;

            for (int i = length / 2; i >= 0; i--)
            {
                Heapify(values, length, i);
            }

            int tempIndex = length;
            for (int i = length - 1; i >= 0; i--)
            {
                int temp = values[0];
                values[0] = values[i];
                values[i] = temp;

                Heapify(values, i, 0);
            }

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{values[i]} ");
            }
            Console.WriteLine($" ");
        }

        public static void RadixSort(int[] values)
        {
            int length = values.Length;

            int maxValue = values[0];

            for (int i = 1; i < length; i++)
            {
                if (maxValue < values[i])
                {
                    maxValue = values[i];
                }
            }

            int maxValueNum = maxValue.ToString().Length;
            for (int i = 0, mod = 10; i < maxValueNum; i++, mod *= 10)
            {
                List<int>[] counter = new List<int>[mod * 2];
                for (int j = 0; j < values.Length; j++)
                {
                    int bucket = (values[j] % mod) / (mod / 10) + mod;
                    if (counter[bucket] == null)
                    {
                        counter[bucket] = new List<int>();
                    }
                    counter[bucket].Add(values[j]);
                }

                int valuesIndex = 0;

                for (int k = 0; k < counter.Length; k++)
                {
                    if (counter[k] != null)
                    {
                        for (int j = 0; j < counter[k].Count; j++)
                        {
                            values[valuesIndex] = counter[k][j];
                            valuesIndex++;
                        }
                    }
                }
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");
            }
        }

        public static void MergeSort(int[] values)
        {
            int length = values.Length;

            if (length >= 2)
            {
                int leftLength = length / 2;
                int rightLength = length - leftLength;
                int[] left = new int[leftLength];
                int[] right = new int[rightLength];

                Array.Copy(values, 0, left, 0, leftLength);
                Array.Copy(values, leftLength, right, 0, rightLength);

                MergeSort(left);
                MergeSort(right);

                Console.Write($"values ");
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");

                Console.Write($"left ");
                for (int k = 0; k < leftLength; k++)
                {
                    Console.Write($"{left[k]} ");
                }
                Console.WriteLine($" ");

                Console.Write($"right ");
                for (int k = 0; k < rightLength; k++)
                {
                    Console.Write($"{right[k]} ");
                }
                Console.WriteLine($" ");


                int leftIndex = 0;
                int rightIndex = 0;

                for (int i = 0; i < length; i++)
                {
                    if (leftIndex < leftLength && rightIndex < rightLength)
                    {
                        if (left[leftIndex] < right[rightIndex])
                        {
                            values[i] = left[leftIndex];
                            leftIndex++;
                        }
                        else
                        {
                            values[i] = right[rightIndex];
                            rightIndex++;
                        }
                    }
                    else
                    {
                        if (leftIndex < leftLength)
                        {
                            values[i] = left[leftIndex];
                            leftIndex++;
                        }
                        if (rightIndex < rightLength)
                        {
                            values[i] = right[rightIndex];
                            rightIndex++;
                        }
                    }
                }

                Console.Write($"values ");
                for (int k = 0; k < length; k++)
                {
                    Console.Write($"{values[k]} ");
                }
                Console.WriteLine($" ");
                Console.WriteLine($" ");

            }
        }
    }
}
