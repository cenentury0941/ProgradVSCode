using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class AsyncProgramming
    {
        static async Task Main(string[] args)
        {
            Task<int> resultantNumber = ReturnNumber();
            FirstMethod();
            await resultantNumber;
            Console.WriteLine($"The number = {resultantNumber.Result} ");
            SecondMethod();
            Console.ReadLine();
        }

        public static async void FirstMethod()
        {

            Console.WriteLine("Method1 has started");
            await Task.Delay(5000);
            Console.WriteLine("Method1 has Ended");
        }

        public static async Task<int> ReturnNumber()
        {
            Thread.Sleep(2000);
            return 10;
        }

        public static async void SecondMethod()
        {
            Console.WriteLine("Method2 has started");
            Console.WriteLine("Method2 has Ended");
        }
    }
}