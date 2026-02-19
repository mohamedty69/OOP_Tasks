using System;
using System.Threading.Tasks;

namespace Asynch_Functions
{
    /// <summary>
    /// REAL-WORLD SCENARIO: Web Server with Limited Threads
    /// Shows WHY freeing threads matters in real applications
    /// </summary>
    public class WebServerScenario
    {
        public static async Task Run()
        {
            Console.WriteLine("??????????????????????????????????????????????????????????????");
            Console.WriteLine("?         REAL-WORLD: WEB SERVER SCENARIO                    ?");
            Console.WriteLine("??????????????????????????????????????????????????????????????\n");

            Console.WriteLine("?? IMAGINE: You have a web server with only 2 threads\n");
            Console.WriteLine("   5 users visit your website at the same time");
            Console.WriteLine("   Each request needs to fetch data from database (takes 3 seconds)\n");

            await ShowBlockingScenario();
            
            Console.WriteLine("\n???????????????????????????????????????????????????????????\n");

            await ShowAsyncScenario();
        }

        // ? Blocking scenario: Can only handle 2 users at a time
        static async Task ShowBlockingScenario()
        {
            Console.WriteLine("? WITHOUT ASYNC/AWAIT (Blocking):\n");
            Console.WriteLine("   [Thread 1] User A's request arrives ? Thread 1 handles it");
            Console.WriteLine("   [Thread 2] User B's request arrives ? Thread 2 handles it");
            Console.WriteLine("   [Thread 1] Fetching from database... BLOCKED! ??");
            Console.WriteLine("   [Thread 2] Fetching from database... BLOCKED! ??");
            Console.WriteLine("   [NONE]     User C's request arrives ? ? NO THREAD AVAILABLE!");
            Console.WriteLine("   [NONE]     User D's request arrives ? ? WAITING...");
            Console.WriteLine("   [NONE]     User E's request arrives ? ? WAITING...\n");
            
            await Task.Delay(1000);
            
            Console.WriteLine("   After 3 seconds:");
            Console.WriteLine("   [Thread 1] User A's request complete ?");
            Console.WriteLine("   [Thread 2] User B's request complete ?");
            Console.WriteLine("   [Thread 1] NOW handling User C... (another 3 seconds)");
            Console.WriteLine("   [Thread 2] NOW handling User D... (another 3 seconds)\n");
            
            Console.WriteLine("   ?? RESULT:");
            Console.WriteLine("      Total time: 9 seconds (3 + 3 + 3)");
            Console.WriteLine("      Users C, D, E had to WAIT!");
            Console.WriteLine("      Poor user experience! ??\n");
        }

        // ? Async scenario: Can handle all 5 users simultaneously
        static async Task ShowAsyncScenario()
        {
            Console.WriteLine("? WITH ASYNC/AWAIT (Non-blocking):\n");
            Console.WriteLine("   [Thread 1] User A's request arrives ? Thread 1 handles it");
            Console.WriteLine("   [Thread 1] Hitting 'await' ? Thread 1 RELEASED! ?");
            Console.WriteLine("   [Thread 1] NOW handling User B's request");
            Console.WriteLine("   [Thread 1] Hitting 'await' ? Thread 1 RELEASED! ?");
            Console.WriteLine("   [Thread 1] NOW handling User C's request");
            Console.WriteLine("   [Thread 1] Hitting 'await' ? Thread 1 RELEASED! ?");
            Console.WriteLine("   [Thread 1] NOW handling User D's request");
            Console.WriteLine("   [Thread 1] Hitting 'await' ? Thread 1 RELEASED! ?");
            Console.WriteLine("   [Thread 1] NOW handling User E's request");
            Console.WriteLine("   [Thread 1] Hitting 'await' ? Thread 1 RELEASED! ?\n");
            
            await Task.Delay(1000);
            
            Console.WriteLine("   All 5 database queries running at the same time!");
            Console.WriteLine("   Thread 1 is FREE to handle even MORE requests!\n");
            
            Console.WriteLine("   After 3 seconds:");
            Console.WriteLine("   [Thread 1] User A's response arrives ? completes ?");
            Console.WriteLine("   [Thread 2] User B's response arrives ? completes ?");
            Console.WriteLine("   [Thread 1] User C's response arrives ? completes ?");
            Console.WriteLine("   [Thread 2] User D's response arrives ? completes ?");
            Console.WriteLine("   [Thread 1] User E's response arrives ? completes ?\n");
            
            Console.WriteLine("   ?? RESULT:");
            Console.WriteLine("      Total time: 3 seconds (all at once!)");
            Console.WriteLine("      All users served quickly!");
            Console.WriteLine("      Excellent user experience! ??\n");

            Console.WriteLine("???????????????????????????????????????????????????????????\n");
            Console.WriteLine("?? THIS IS THE ANSWER TO YOUR QUESTION:\n");
            Console.WriteLine("   'Which thread is free?'");
            Console.WriteLine("   ? The thread executing your code (Thread 1 in this example)\n");
            
            Console.WriteLine("   'How is it used?'");
            Console.WriteLine("   ? It goes back to handle OTHER incoming work:");
            Console.WriteLine("     - Other user requests");
            Console.WriteLine("     - Other operations");
            Console.WriteLine("     - Anything waiting in the queue\n");
            
            Console.WriteLine("   'What about the database query?'");
            Console.WriteLine("   ? The database server handles it");
            Console.WriteLine("   ? No .NET thread is needed while waiting");
            Console.WriteLine("   ? When done, a thread (any available one) continues\n");
        }
    }
}
