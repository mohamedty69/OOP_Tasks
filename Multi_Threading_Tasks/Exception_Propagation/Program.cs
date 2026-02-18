namespace Exception_Propagation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // All this try catch block will be excuted because it is run on the main thread and the exception is not handeld in the method where it is thrown, so it will be propagated to the main thread and handeld there.
            //try
            //{
            //    ThrowException();
            //}
            //catch 
            //{
            //    Console.WriteLine("Not handeld exception !!!");
            //} (code)

            // -- 1 --
            // In this case the exception will not be handeld because the calling of method (ThrowException()) it is run on a different thread and the exception is not handeld in the method where it is thrown, so it will be propagated to the main thread but it will not be handeld there because it is a different thread.
            //try
            //{
            //    var th = new Thread(() => ThrowException());
            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("Not handeld exception !!!");
            //}

            // -- 2 --
            //var th = new Thread(() => ThrowExceptionByTryCatchBlock());
            //th.Start();
            //th.Join();

            // -- 3 --
            // In this case the exception will not cought by the thread that Task create to run the method (ThrowException()) because the exception is not handeld in the method where it is thrown, so it will be propagated to the main thread and handeld there because Task will propagate the exception to the main thread.
            try
            {
                Task.Run(() => ThrowException()).Wait();
            }
            catch  
            {
                Console.WriteLine("Not handeld exception !!!");
            }
        }
        static void ThrowException()
        {
            throw new NullReferenceException();
        }
        static void ThrowExceptionByTryCatchBlock()
        {
            try
            {
                ThrowException();
            }
            catch 
            {
                Console.WriteLine("Not handeld exception !!!");
            }
        }
    }
}
