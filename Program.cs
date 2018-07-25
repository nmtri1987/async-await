using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Async
{
    public class MyService
    {
        public async Task<int> DoWork(string taskDescription)
        {
            Console.WriteLine($"            -> Before DoWork - {taskDescription}: THREAD id: {Thread.CurrentThread.ManagedThreadId }");
            for (int i = 0; i != 10000000; ++i) ;
            await Task.Delay(2000);
            Console.WriteLine($"            -> After DoWork - {taskDescription}: THREAD id:  {Thread.CurrentThread.ManagedThreadId }");

            return 42;
        }
        public Task<int> DoWorkTask()
        {
            Console.WriteLine("        + Before 1 (Task)");
            var result = Task.Run(() => DoWork("Task 1 (Task)"));
            Console.WriteLine("        + After 1 (Task)");
            return result;
        }
        public async Task<int> DoWorkAsync() //Called from UI
        {
            Console.WriteLine("        + Before 2 (Async)");
            var result = await DoWork("Task 2 (Async)"); //Task.Run(() => DoWork());
            Console.WriteLine("        + After 2 (Async)");
            return result;
        }

        public async Task DoDeadLock() //Called from UI
        {
            Console.WriteLine("        + Before 3 (Deadlock)");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("        + After 3 (Deadlock)");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"*** START with THREAD Id: {Thread.CurrentThread.ManagedThreadId }");
            var myService = new MyService();
            Console.WriteLine("     - Calling 1 (Task)");
            myService.DoWorkTask();
            Console.WriteLine("     - Calling 2 (Async)");
            myService.DoWorkAsync();
            Console.WriteLine("     - Calling 3 (Deadlock)");
            var task = myService.DoDeadLock();
            task.Wait();
            Console.WriteLine("*** END");
            Console.ReadLine();
        }
    }
}
