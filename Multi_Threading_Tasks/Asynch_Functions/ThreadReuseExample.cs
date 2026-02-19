using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Asynch_Functions
{
    /// <summary>
    /// THIS EXAMPLE ANSWERS: "Which thread is free and how is it used?"
    /// Shows how ONE thread can handle MULTIPLE operations using async/await
    /// </summary>
    public class ThreadReuseExample
    {
        public static async Task Run()
        {
            Console.WriteLine("??????????????????????????????????????????????????????????????");
            Console.WriteLine("?  WHICH THREAD IS FREE? HOW IS IT USED?                    ?");
            Console.WriteLine("??????????????????????????????????????????????????????????????\n");

            Console.WriteLine("?? THE QUESTION:");
            Console.WriteLine("   When I use 'await', which thread is free?");
            Console.WriteLine("   And how does it get used?\n");

            Console.WriteLine("?? THE ANSWER:");
            Console.WriteLine("   - The thread EXECUTING your code gets freed");
            Console.WriteLine("   - It returns to the 'thread pool'");
            Console.WriteLine("   - The thread pool REUSES it for other work");
            Console.WriteLine("   - In web apps: handles other incoming requests!");
            Console.WriteLine("   - In your app: can process other operations!\n");

            await ShowThreadReuseInAction();
        }

        static async Task ShowThreadReuseInAction()
        {
            Console.WriteLine("???????????????????????????????????????????????????????????\n");
            Console.WriteLine("?? DEMONSTRATION: ONE Thread Handling THREE Operations\n");
            Console.WriteLine("???????????????????????????????????????????????????????????\n");
            Console.WriteLine($"Started thread {Thread.CurrentThread.ManagedThreadId}");

            var sw = Stopwatch.StartNew();

            // Simulate 3 web requests (each takes 2 seconds)
            // Watch how the SAME thread handles all 3!
            
            var task1 = HandleRequestAsync("Request-A", 1);
            var task2 = HandleRequestAsync("Request-B", 2);
            var task3 = HandleRequestAsync("Request-C", 3);

            await Task.WhenAll(task1, task2, task3);

            sw.Stop();

            Console.WriteLine("\n???????????????????????????????????????????????????????????");
            Console.WriteLine($"??  TOTAL TIME: {sw.ElapsedMilliseconds}ms (about 2 seconds, not 6!)");
            Console.WriteLine("???????????????????????????????????????????????????????????\n");

            Console.WriteLine("?? WHAT HAPPENED:");
            Console.WriteLine("   1. Thread started Request-A, then was RELEASED by 'await'");
            Console.WriteLine("   2. SAME thread started Request-B, then was RELEASED");
            Console.WriteLine("   3. SAME thread started Request-C, then was RELEASED");
            Console.WriteLine("   4. Thread was FREE to do other work");
            Console.WriteLine("   5. When responses came back, thread continued each request\n");

            Console.WriteLine("?? KEY POINT:");
            Console.WriteLine("   ONE thread handled THREE operations concurrently!");
            Console.WriteLine("   This is the POWER of async/await!\n");
        }

        static async Task HandleRequestAsync(string requestName, int id)
        {
            var startThread = Environment.CurrentManagedThreadId;
            
            Console.WriteLine($"[Thread {startThread}] ?? {requestName}: Started");
            Console.WriteLine($"[Thread {startThread}] {requestName}: Sending web request...");
            Console.WriteLine($"[Thread {startThread}] {requestName}: Hitting 'await' - RELEASING thread!\n");
            
            // Simulate a web request (2 seconds)
            await Task.Delay(2000);
            
            var endThread = Environment.CurrentManagedThreadId;
            Console.WriteLine($"[Thread {endThread}] ? {requestName}: Response received! Completed!\n");
        }
    }
}
