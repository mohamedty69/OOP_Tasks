namespace Multi_Threading_Task_LongThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Talk about long runing and short running operations
            // Long running operattions: operations that the start time > excution time, such as: file I/O, network I/O, database operations, etc.
            // Short running operations: operations that the start time < excution time, such as: CPU-bound operations, calculations, etc.
            // Start time: the time when the task is started.
            var task = Task.Factory.StartNew(() => RunLongThread(),
                TaskCreationOptions.LongRunning);
            task.GetAwaiter().GetResult();

            // Long running operations: will be not use pool threads, but will create a new thread to run the task.
            // poor threads: is false for long running operations, but is true for short running operations.
            // Note that: Threads that created with Task class is pool threads by default, and background threads by default, but when we use TaskCreationOptions.LongRunning, the thread will be not a pool thread, and not a background thread.

        }
        static void RunLongThread()
        {
            Thread.Sleep(3000);
            ShowThreadInfo();
            Console.WriteLine("\nCompleted");
        }
        static void ShowThreadInfo()
        {
            Console.Write($"Thread ID: {Thread.CurrentThread.ManagedThreadId} ");
            Console.Write($"Is Thread Pool Thread: {Thread.CurrentThread.IsThreadPoolThread} ");
            Console.Write($"Background: {Thread.CurrentThread.IsBackground} ");
        }
    }
}