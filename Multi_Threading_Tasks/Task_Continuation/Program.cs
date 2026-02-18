using System.Runtime.CompilerServices;

namespace Task_Continuation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // -- 1 --
            var task = Task.Run(() => CountPrineNumberInRange(2, 1000000));
            // Console.WriteLine(task.Result); // bad using of task.Result because it will block the main thread until the task is completed.
            // Console.WriteLine("Mohamed"); // Mohamed here will not be printed until the task is completed because of the blocking of the main thread by task.Result, so it will be printed after the result of the task is printed.

            // -- 2 --
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
               // Console.WriteLine(awaiter.GetResult()); // this is good using of task.GetAwaiter() because it will not block the main thread and it will print the result of the task when it is completed without blocking the main thread, so Mohamed here will be printed before the result of the task is printed.
            //});
            //Console.WriteLine("Mohamed");

            task.ContinueWith((x) => Console.WriteLine(x.Result)); // this is good using of task.ContinueWith() because it will not block the main thread and it will print the result of the task when it is completed without blocking the main thread, so Mohamed here will be printed before the result of the task is printed.
            Console.WriteLine("Mohamed");
            Console.ReadKey();
        }
        static int CountPrineNumberInRange(int lowerBound,int upperBound)
        {
            var c = 0; 
            for (int i = lowerBound; i < upperBound; i++)
            {
                var isPrime = true;
                for (int j = lowerBound; j <= (int)Math.Sqrt(i); j++)
                {
                    if (i % j == 0 && i != j)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    c++;
            }
            return c;
        }
    }
}
