using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    // InnRoad test task
    // https://www.innroad.com/
    // Given 2 unbounded and unsorted arrays, a1 & a2,
    // print to the console every pair of values that add up to 0
    // Output should be something like this: (order is not important)
    // 0, 0
    // 6, -6
    // -1, 1
    // var a1 = new[] { 0, -3, 6, 8, -1 };
    // var a2 = new[] { 1, 8, -3, 0, 15, -11, -6 };


    internal class Program
    {
        static void Main(string[] args)
        {
            int max1 = 10000;
            int max2 = 10000;
            Random rm = new Random();

            Stopwatch stopwatch = new Stopwatch();

            int[] a1 = Enumerable.Range(0, max1).ToArray();
            int[] a2 = Enumerable.Range(0, max2).ToArray(); ;


            //init task values
            a1[1] = -a1[1];
            a1[3] = -a1[3];
            a2[3] = -a2[3];
            a2[6] = -a2[6];
           

            //shaffle a2 array
            for (int n = 0; n < max2; n++)
            {
                int rnd = rm.Next(max2);

                int temp = a2[n];
                a2[n] = a2[rnd];
                a2[rnd] = temp;
            }


            stopwatch.Start();
            Solve1(a1, a2);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time for Solve1 is {0} ms", stopwatch.ElapsedMilliseconds);
          
            stopwatch.Reset();

            stopwatch.Start();
            Solve2(a1, a2);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time for Solve2 is {0} ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Complexity of 2nd is better than 1st one for {0} elements, press any key", max2);
            Console.ReadKey();
        }

        //1st algorithm
        static void Solve1(int[] a1, int[] a2)
        {
            
            foreach (var a_1 in a1)
            {
                foreach (var a_2 in a2)
                {
                    if((a_1 + a_2) == 0 )
                    {
                        Console.WriteLine(String.Format("{0}, {1}", a_1, a_2));
                    }
                }
            }

            Console.WriteLine("Complexity of 1st = O(N pow 2)");           
        }

        //2nd algorithm
        static void Solve2(int[] a1, int[] a2)
        {            
            int [] a2_s = a2.OrderBy(x => x).ToArray<int>();

            foreach (var a_1 in a1)
            {               
                int target = -a_1;

                int pos = Array.BinarySearch(a2_s, target);

                if (pos >= 0)
                {
                    Console.WriteLine(String.Format("{0}, {1}", a_1, a2_s[pos]));
                }
            }

            Console.WriteLine("Complexity of 2nd = O(N log(N))");           
        }
    }
}
