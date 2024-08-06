using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迷宫算法
{
    class Program
    {
        public static int weight = 22;
        public static int hight = 22;
        public static Random random = new Random(DateTime.Now.Second);
        public static char[,] mapArry = new char[weight, hight];
        static void Main(string[] args)
        {
            Init(1, 1);
            m[1, 0] = m[v - 2, u - 1] = 1;
            for (int y = 0; y < v; y++)
            {
                for (int x = 0; x < u; x++)
                {
                    Console.Write((m[y, x] == 1) ? "  " : "回");
                }
                Console.WriteLine("");
            }

        }

        static int[,] m = new int[50, 50];
        static int[,] d = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        static int w = 16, h = 16, u = w * 2 + 1, v = h * 2 + 1;
        static Random num = new Random();
        static int Init(int y, int x)
        {
            if (x < 1 || y < 1 || x >= u - 1 || y >= v - 1 || m[y, x] == 1)
            {
                return 0;
            }
            else
            {
                m[y, x] = 1;
            }

            for (int f = num.Next() % 4, i = 0, p = (num.Next() & 1) == 1 ? 3 : 1; i < 4; ++i, f = (f + p) % 4)
            {
                if (Init(y + d[f, 0] * 2, x + d[f, 1] * 2) == 1)
                {
                    m[y + d[f, 0], x + d[f, 1]] = 1;
                }
            }
            return 1;
        }

        public static void InitMapArry()
        {
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    if (i != 0 && i != weight - 1 && j != 0 && j != hight - 1)
                    {
                        mapArry[j, i] = '回';
                    }
                    else
                    {
                        mapArry[j, i] = '路';
                    }
                }
            }
        }

        public static void InitMap()
        {
            int postionX = 2;
            int postionY = 2;
            for (int i = 2; i < hight - 2; i++)
            {
                for (int j = 2; j < weight - 2; j++)
                {
                    int distance = random.Next(1, 5);
                    //while (postionX < 0 || postionX > weight || postionY < 0 || postionY > hight)
                    //{
                    //    postionX = random.Next(2, weight - 2);
                    //    postionY = random.Next(2, hight - 2);
                    //}

                    switch (distance)
                    {
                        case 1:
                            if (mapArry[j, i - 2] == '回')
                            {
                                CteateRode(j, i);
                            }
                            else
                            {
                                Cteatewell(j, i);
                            }
                            break;
                        case 2:
                            if (mapArry[j, i + 2] == '回')
                            {
                                CteateRode(j, i);

                            }
                            else
                            {
                                Cteatewell(j, i);
                            }
                            break;
                        case 3:
                            if (mapArry[j - 2, i] == '回')
                            {
                                CteateRode(j, i);
                            }
                            else
                            {
                                Cteatewell(j, i);
                            }
                            break;
                        case 4:
                            if (mapArry[j + 2, i] == '回')
                            {
                                CteateRode(j, i);

                            }
                            else
                            {
                                Cteatewell(j, i);
                            }
                            break;
                    }

                }
            }
        }

        public static void CteateRode(int j, int i)
        {
            char temp = '路';
            mapArry[j, i] = temp;
            mapArry[j + 2, i] = temp;
            mapArry[j - 2, i] = temp;
            mapArry[j, i + 2] = temp;
            mapArry[j, i - 2] = temp;
        }
        public static void Cteatewell(int j, int i)
        {
            char temp = '回';
            mapArry[j, i] = temp;
            mapArry[j + 2, i] = temp;
            mapArry[j - 2, i] = temp;
            mapArry[j, i + 2] = temp;
            mapArry[j, i - 2] = temp;
        }

        public static void PrintMap()
        {
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    if (mapArry[j, i] == '回')
                    {
                        Console.Write("回");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }


    }



}
