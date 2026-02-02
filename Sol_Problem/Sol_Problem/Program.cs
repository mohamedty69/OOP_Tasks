using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Channels;
namespace Sol_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            long count(long n)
            {
                var l = new List<long>();
                for (long i = 1; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        l.Add(i);
                        if (n / i != i)
                        {
                            l.Add(n / i);
                        }
                    }
                }
                return l.Count;
            }
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                long n = long.Parse(Console.ReadLine());
                Console.WriteLine(count(n));
            }
        }
    }
}