using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITool tool = new Tool("Tool 1", 2);
            ITool tool4 = new Tool("Tool 4", 1);
            ITool tool2 = new Tool("Tool 2", 5);
            ITool tool3 = new Tool("Tool 3", 1);
            IToolCollection collection = new ToolCollection(5);
            Console.WriteLine(collection.Search(tool));
            collection.Add(tool);
            collection.Add(tool4);
            collection.Add(tool2);
            collection.Add(tool3);
            collection.Add(tool);
            Console.WriteLine(collection.Search(tool));
            collection.Delete(tool);
            Console.WriteLine(collection.Search(tool));
            Console.WriteLine(collection.Search(tool2));
            collection.Clear();
            Console.WriteLine(collection.Search(tool2));
            collection.Add(tool);
            Console.WriteLine(collection.Search(tool));

            tool.IncreaseQuantity(4);
            tool.DecreaseQuantity(2);
            tool4.IncreaseQuantity(40);
            tool4.DecreaseQuantity(3);
            tool.AddBorrower("James");
            tool.AddBorrower("Kevin");
            tool.AddBorrower("Dan");
            tool4.AddBorrower("Ben");
            Console.WriteLine(tool.SearchBorrower("James"));
            tool.DeleteBorrower("James");
            Console.WriteLine(tool.SearchBorrower("James"));
            Console.WriteLine(tool4.SearchBorrower("Ben"));
        }
    }
}