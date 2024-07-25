namespace 排序算法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 9, 8, 5, 6, 4, 2, 3, 1, 7, 0 };
            BubbleSort(values);
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
            }

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(values[i]);
            }
        }

        public static void SelectionSort(int[] values)
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
            }

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(values[i]);
            }
        }

        public static void QuickSort(int[] values)
        {

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(values[i]);
            }
        }
    }
}
