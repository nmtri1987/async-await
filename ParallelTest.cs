public class Program
    {
        private static DateTime begin = DateTime.Now;
        private static DateTime beginParallel = DateTime.Now;
        public static int CalculateMandelbrot(int counter)
        {
            for (int x = 0; x <= counter; x++)
            {
                for (int i = 0; i != 1000000000; ++i)
                    ;
            }
            return 42;
        }

        static void Main(string[] args)
        {
            Go();
        }
        public static void Go()
        {
            GoAsync();
            Console.WriteLine("*** Other Works 111 ***");
            Console.ReadLine();
        }
        public static async void GoAsync()
        {
            Console.WriteLine("##### Starting #####");
            

            Console.WriteLine($"*** START longest task: 6 times at {DateTime.Now}");
            var longestTask = Sleep(6, begin);
            var xxx = longestTask.Result;
            Console.WriteLine($"*** END longest task: 6 times at {DateTime.Now} - TAKEN: {DateTime.Now-begin}");

            Console.WriteLine("====================");

            beginParallel = DateTime.Now;
            Console.WriteLine($"*** START Parallel tasks at {beginParallel}");
            var task1 = Sleep(4, beginParallel);
            var task2 = Sleep(2, beginParallel);
            var task3 = Sleep(6, beginParallel);

            int[] result = await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("*** Other Works 222 ***");
            Console.WriteLine($"-> Looping for a total of {result.Sum()} times: {DateTime.Now} - TAKEN: {DateTime.Now - beginParallel}");
        }

        private async static Task<int> Sleep(int counter, DateTime dtBegin)
        {
            Console.WriteLine($"- START Looping for {counter} times at {DateTime.Now}");
            //await Task.Delay(ms);
            await Task.Run(() => CalculateMandelbrot(counter));
            Console.WriteLine($"- STOP Looping for {counter} times finished at {DateTime.Now} - TAKEN: {DateTime.Now - dtBegin}");

            return counter;
        }
    }
