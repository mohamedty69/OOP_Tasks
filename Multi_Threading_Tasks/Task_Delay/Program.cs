namespace Task_Delay
{
    public class Program
    {
        static void Main(string[] args)
        {
            DelayUsinTask(6000);
            Console.WriteLine("Hello, World!");
            Console.ReadLine();

            //SleepUsingTread(6000);
            //Console.WriteLine("Hello, World!");
            //Console.ReadLine();
        }
        // Task Delay is a asynchronus method that is used to delay the execution of a task for a specified amount of time, it is useful when you want to simulate a long running task or when you want to wait for a certain amount of time before executing a task.
        // Thread.Sleep() is a synchronous method that is used to block the current thread for a specified amount of time, it is not recommended to use it in a asynchronus method because it will block the main thread and it will not allow other tasks to run while it is sleeping, so it is better to use Task.Delay() instead of Thread.Sleep() in a asynchronus method.


        // Using task to make a delay that make logical delay you need to deal with it to run 
        //static void DelayUsinTask(int delay) // this method will not working and not wait the (delay value) to end so you need to use the methods that make Task run 
        //{
        //    Task.Delay(delay);
        //    Console.WriteLine($"Completed after Task.Delay({delay})");
        //} (code)

        // This will make the Task run and wait for the delay to end before executing the next line of code, it will not block the main thread and it will allow other tasks to run while it is waiting for the delay to end, so it is better to use Task.Delay() instead of Thread.Sleep() in a asynchronus method.
        static void DelayUsinTask(int delay) // this method will not working and not wait the (delay value) to end so you need to use the methods that make Task run 
        {
            // Only lines of code that is in OnCompleted() will be executed after the delay is completed, and the rest of the code will be executed immediately without waiting for the delay to end, so you need to put all the code that you want to execute after the delay inside the OnCompleted() method.
            Task.Delay(delay).GetAwaiter().OnCompleted(() =>
            { 
            Console.WriteLine($"Completed after Task.Delay({delay})");
            });
            Console.WriteLine("Completed!!!!");
        }


        static void SleepUsingTread(int delay)
        {
            Thread.Sleep(delay);
            Console.WriteLine($"Completed after Tread.Sleep({delay})");
        }
    }
}
