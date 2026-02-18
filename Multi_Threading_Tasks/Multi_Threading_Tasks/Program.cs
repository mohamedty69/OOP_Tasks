using System;



namespace Multi_Threading_Tasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(() => GetDateTime());

            // return Task object, not the result of the task.
            // Output: System.Threading.Tasks.Task`1[System.DateTime] 
            //Console.WriteLine(task); // code

            // return the result of the task, which is the current date and time.
            // It will block the main thread until the task is completed.
            //Console.WriteLine(task.Result); // code
            // same use 
            Console.WriteLine(task.GetAwaiter().GetResult());
        }

        public static DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
