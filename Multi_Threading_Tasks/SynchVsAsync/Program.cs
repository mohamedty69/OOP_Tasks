namespace SynchVsAsync
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(7);
            CallSynchronous();

            ShowThreadInfo(10);
            CallAsynchtonous();

            ShowThreadInfo(13);
            Console.ReadKey();

            // Output:
            // Line: 7 Thread ID: 1 Is Thread Pool Thread: False Background: False
            // Line: 31 Thread ID: 1 Is Thread Pool Thread: False Background:False
            // +++++++++++Synch+++++++++                                     False
            // Line: 10 Thread ID: 1 Is Thread Pool Thread: False Background:False
            // Line: 36 Thread ID: 1 Is Thread Pool Thread: False Background:False
            // Line: 13 Thread ID: 1 Is Thread Pool Thread: False Background:False
            // Line: 27 Thread ID: 7 Is Thread Pool Thread: True Background: False
            // +++++++++++Asynch+++++++++

            // Look to this output you can notice that the synchronous method (CallSynchronous()) is blocking the main thread until it is completed, but the asynchronous method (CallAsynchtonous()) is not blocking the main thread and it allows other tasks to run while it is waiting for the delay to end, so it is better to use asynchronous methods instead of synchronous methods when you want to perform long running operations or when you want to wait for a certain amount of time before executing a task.
        }
        static void CallSynchronous()
        {
            Thread.Sleep(5000);
            ShowThreadInfo(31);
            Task.Run(() => Console.WriteLine("++++++++++Synch+++++++++")).Wait();
        }
        static void CallAsynchtonous()
        {
            ShowThreadInfo(36);
            Task.Delay( 5000).GetAwaiter().OnCompleted(() => {
                ShowThreadInfo(27);
                Console.WriteLine("++++++++++Asynch+++++++++");
            });
            
        }
        static void ShowThreadInfo(int line)
        {
            Console.WriteLine($"Line: {line} "+
            $"Thread ID: {Thread.CurrentThread.ManagedThreadId} "+
            $"Is Thread Pool Thread: {Thread.CurrentThread.IsThreadPoolThread} "+
            $"Background: {Thread.CurrentThread.IsBackground} ");
        }
    }
}
