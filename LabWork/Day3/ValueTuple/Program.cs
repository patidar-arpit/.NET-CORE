namespace ValueTuple
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ValueTuple<int, int> vto = new ValueTuple<int, int>();

            var tuple1 = (1, 2);
            var tuple2 = (2, 3);

            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item2);

        }
        static void Main(string[] args)
        {

            var NamedTuple = (language: "c#", tool: "laptop", abc: "xyx");


            Console.WriteLine(display(NamedTuple));
            Console.WriteLine(NamedTuple.GetHashCode());

        }

        private static ValueTuple<string, string> display((string language, string tool, string abc) NamedTuple)
        {
            Console.WriteLine(NamedTuple.GetHashCode());
            Console.WriteLine(NamedTuple.language);
            Console.WriteLine(NamedTuple.tool);
            Console.WriteLine(NamedTuple.abc);

            NamedTuple.language = "Java";
            NamedTuple.tool = "PC";
            Console.WriteLine(NamedTuple.language);
            Console.WriteLine(NamedTuple.tool);
            Console.WriteLine(NamedTuple.abc);
            Console.WriteLine(NamedTuple.GetHashCode());

            var newNamedTuple = (language: NamedTuple.language, tool: NamedTuple.tool);

            return newNamedTuple;

        }
    }
}