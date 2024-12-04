namespace Homework3._1
{
    class Program
    {
        static void Main()
        {
            var tree = new BinarySearchTree();


            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);


            Console.WriteLine(tree.Contains(7));
            Console.WriteLine(tree.Contains(20));


            int[] values = tree.ToArray();
            Console.WriteLine(string.Join(", ", values));


            tree.Clear();
            Console.WriteLine(tree.Count);
        }
    }

}
