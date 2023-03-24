namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> l1 = new LinkedList<string>();

            l1.AddLast("a");
            l1.AddLast("b");
            l1.AddLast("c"); l1.AddLast("a");

            l1.AddFirst("d"); l1.AddLast("a");
            l1.AddFirst("e");
            l1.AddFirst("f"); l1.AddLast("a");

            l1.AddAfter( l1.Find("b") , "G" );

            LinkedListNode<string> node;

            




            foreach (var val in l1)
            {
                Console.Write(val + " ");
            }

            Console.WriteLine("\n\n");


            LinkedListNode<string> current = l1.First;
            do {
                if ( current.Value == "a" )
                {
                    l1.AddBefore(current, "5");
                }
                current = current.Next;
            }
            while ( current.Next != null );

            if ( current.Value == "a" )
            {
                l1.AddBefore(current, "5");
            }

            foreach (var val in l1)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine("\n\n");


            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add(1, "abc");
            dic.Add(2, "def");

            dic[1] = "ijk";


            foreach (KeyValuePair<int, string> kv in dic)
            {
                Console.WriteLine(kv);
            }
            Console.WriteLine("\n\n");



            SortedDictionary<string, string> sortdic = new SortedDictionary<string, string>();

            sortdic.Add("a", "abc");
            sortdic.Add("f", "def");
            sortdic.Add("sdf", "dsfdsfdef");
            sortdic.Add("sd", "desdfdf");
            sortdic.Add("fd", "defdfdfdfdfdf");

            sortdic.OrderBy(x => x).ToList();

            sortdic.GetValueOrDefault("a");

            foreach (KeyValuePair<string, string> kv in sortdic)
            {
                Console.WriteLine(kv);
            }



        }
    }
}