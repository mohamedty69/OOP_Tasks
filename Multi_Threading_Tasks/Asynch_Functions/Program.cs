using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Asynch_Functions
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Old way of doing asynchronous programming using Task and GetAwaiter
            //var task = Task.Run(() => ReadContent("https://www.google.com"));
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult())); (code)

            //var result = ReadContentAsync("https://www.google.com").GetAwaiter().GetResult();
            // or you can do it like this
            // put need to make the Main method return type async Task instead of void and use await keyword to wait for the result of the asynchronous operation before proceeding with the next line of code.
            //var result2 = await ReadContentAsync("https://www.google.com");
            //Console.WriteLine(result); (code)

            // Uncomment to test your original code
            //var result = await TrySomethinAsync("https://www.google.com");
            //Console.WriteLine(result);
            //DoSomethingAfter();
            // =========================================================
            // 🎯 TO UNDERSTAND: "Which thread is free? How is it used?"
            // Run these examples:
            
            // Best example: Shows ONE thread handling MULTIPLE operations
            await ThreadReuseExample.Run();
            
            // Real-world scenario: Web server with limited threads
            //await WebServerScenario.Run();
            
            // All examples
            //await ExamplesRunner.RunAllExamples();
            // =========================================================



            Console.ReadKey();
        }
        // Old way to define an asynchronous function that returns a Task<string>
        static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(url);
            return task;
        }

        // New way to define an asynchronous function using async and await keywords that make the same thing but with cleaner syntax and better readability
        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();
            // Await the asynchronous operation and return the result directly without needing to manage the Task object manually
            // if you notice in old way this line of code return object of type Task<string> but in new way it return result of type string directly because we are awaiting the result of the asynchronous operation before returning it.
            // We put the await keyword before the asynchronous operation to indicate that we want to wait for the result of that operation before proceeding with the next line of code. This allows us to write asynchronous code in a more synchronous style, improving readability and maintainability.
            // The main condention is use the async keyword you must use await keyword inside the function and return type of the function must be Task or Task<T> where T is the type of the result that you want to return from the asynchronous operation.
            var content = await client.GetStringAsync(url);
            return content;
        }

        //===============================================================
        static async Task<string> TrySomethinAsync(string url)
        {
            var client = new HttpClient();
            DoSomethingBefore();
            var content = await client.GetStringAsync(url);
            return content;
        }
        static void DoSomethingBefore()
        {
            Console.WriteLine("Something before await"); 
        }
        static void DoSomethingAfter()
        {
            Console.WriteLine("Something After await");
        }
    }
}
