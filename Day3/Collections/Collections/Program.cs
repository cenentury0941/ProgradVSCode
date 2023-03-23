using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TemplateClass<string> c1 = new TemplateClass<string>("Arguement");
            TemplateClass<int> c2 = new TemplateClass<int>(69);
            c2.PrintVal(420.0f);
            c2.PrintVal("(O_O)");

            List<string> l1 = new List<string>();
            for ( int i = 0; i < 5; i++ )
            {
                l1.Add($"-{i}-");
            }

            foreach ( string str in l1 )
            {
                Console.WriteLine(str);
            }

            l1.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("");


            Console.WriteLine("HashSet");
            HashSet<string> NoDupes = new HashSet<string>() { "a" , "b" , "c" , "d" , "a" , "c" } ;
            foreach( string s in NoDupes )
            {
                Console.WriteLine(s);
            }



            Console.WriteLine("\nSortedSet");
            SortedSet<string> SortedAndUnique = new SortedSet<string>() { "a", "b", "z" , "c", "d", "a", "c" };
            foreach (string s in SortedAndUnique)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nStack");
            Stack<string> stack1 = new Stack<string>();
            stack1.Push("A");
            stack1.Push("B");
            stack1.Push("C");

            string peekvalue;
            while (stack1.Count != 0)
            {
                Console.Write( stack1.Pop() + " | " );
                if (stack1.TryPeek(out peekvalue)) {
                    Console.WriteLine($"Peak element : {peekvalue}");
                }
            }

            Console.WriteLine("\nQueue");

            Queue<string> queue1 = new Queue<string>();
            queue1.Enqueue("A");
            queue1.Enqueue("B");
            queue1.Enqueue("C");
            queue1.Enqueue("B");


            while (queue1.Count != 0)
            {
                Console.WriteLine(queue1.Dequeue() + " | ");
                
            }


        }
    }

    class TemplateClass<T>
    {
        public TemplateClass(T arg) 
        {
            Console.WriteLine( $"Arg type = {arg.GetType()} | Value = {arg}" );
        }

        public void PrintVal<T>(T val) {

            Console.WriteLine( $"The Value is {val}" );
        }
    }
}