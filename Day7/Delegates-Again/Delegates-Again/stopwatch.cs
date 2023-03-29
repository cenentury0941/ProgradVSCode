namespace DelegateTypes
{
    internal class Program
    {
        public static async Task<string> method1()
        {
            Console.WriteLine("Hello 1 started");
            Console.WriteLine("Message in method1");

            Console.WriteLine(await Program.method2());
            Console.WriteLine("Hello 1 ended");
            return "completed method1";
        }

        public static async Task<string> method2()
        {
            Console.WriteLine("Hello 2 started");
            Task.Delay(7000);
            string msg = "Mesage from method2";
            Console.WriteLine("Hello 2 ended");
            return msg;
        }

        public static async Task<int> method3()
        {
            Console.WriteLine("dummy method");
            return 3;


        }
        static void Main(string[] args)
        {
            var calculation = new System.Diagnostics.Stopwatch();
            calculation.Start();
            Program.method1();
            //Program.method1();
            Console.WriteLine("Calling method3");
            int ans = Program.method3().Result;
            Console.WriteLine("ans " + ans);

            calculation.Stop();
            Console.WriteLine("Elapsed time:" + calculation.ElapsedMilliseconds);
            Console.ReadLine();

        }


    }
}