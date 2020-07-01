using System;

namespace MyFirstConsole
{
    class Program
    {
        static int[] a = {1, 2, 3};
        static int[] b;

        static void Main(string[] args)
        {
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }

            b = new int[5];
            (int,int) aa = (3, 2);
            Console.WriteLine(aa);
            // PrintArr(b);
            // ReadArr(b);
            // PrintArr(b);
            // ReadArr_P(b);
            // PrintArr(b);
        }

        
        
        static int ReadArr(int[] c)
        {
            int a;
            Console.WriteLine("\nEnter {0} Digitals :", c.Length);
            for (int i = 0; i < c.Length; i++)
            {
                Console.Write("Enter {0} digital --> ", i + 1);
                a = ReadInt();
                c[i] = a;
            }

            return 0;
        }

        static int PrintArr(int[] c)
        {
            for (int i = 0; i < c.Length; i++)
                Console.Write(c[i] + " ");
            return 0;
        }

        static int ReadInt()
        {
            const int ZERO = 48;
            int c, a = 0;
            do
            {
                c = Console.Read();
                if (c >= ZERO && c < ZERO + 10)
                {
                    a = a * 10 + (c - ZERO);
                }
                else
                {
                    Console.ReadLine();
                    break;
                }

            } while (c != -1);

            return a;
        }

        static int ReadArr_P(int[] c)
        {
            Console.WriteLine();
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = Int32.Parse(Console.ReadLine());        
            }
        return 0;
        }
    }

}