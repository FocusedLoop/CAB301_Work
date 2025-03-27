using System;
using System.Diagnostics;
using System.Text.Json;

namespace Assignment1
{
    class Program
    {
        static void test()
        {
            int totalTests = 0;
            int passedTests = 0;

            void Assert(bool condition, string testName)
            {
                totalTests++;
                if (condition)
                {
                    Console.WriteLine($"{testName}: Passed");
                    passedTests++;
                }
                else
                {
                    Console.WriteLine($"{testName}: Failed");
                }
            }

            ITool tool = new Tool("Tool 1", 2);
            ITool tool2 = new Tool("Tool 2", 5);
            ITool tool3 = new Tool("Tool 3", 1);
            ITool tool4 = new Tool("Tool 4", 1);
            IToolCollection collection = new ToolCollection(5);

            Console.WriteLine("==== ToolCollection Tests ====");

            Assert(collection.Search(tool) == false, "Test 1: Search Tool 1 before adding");

            collection.Add(tool);
            collection.Add(tool4);
            collection.Add(tool2);
            collection.Add(tool3);
            collection.Add(tool);

            Assert(collection.Search(tool) == true, "Test 2: Search Tool 1 after adding");

            collection.Delete(tool);
            Assert(collection.Search(tool) == false, "Test 3: Search Tool 1 after deletion");
            Assert(collection.Search(tool2) == true, "Test 4: Search Tool 2 (should be true)");

            collection.Clear();
            Assert(collection.Search(tool2) == false, "Test 5: Search Tool 2 after clear");

            collection.Add(tool);
            Assert(collection.Search(tool) == true, "Test 6: Re-add Tool 1 and search");

            Console.WriteLine("\n==== Quantity Tests ====");

            Assert(tool.IncreaseQuantity(4) == true, "Test 7: Increase Tool 1 Quantity by 4");
            Assert(tool.DecreaseQuantity(2) == true, "Test 8: Decrease Tool 1 Quantity by 2");
            Assert(tool4.IncreaseQuantity(40) == true, "Test 9: Increase Tool 4 Quantity by 40");
            Assert(tool4.DecreaseQuantity(3) == true, "Test 10: Decrease Tool 4 Quantity by 3");

            Console.WriteLine("\n==== Borrower Tests ====");

            Assert(tool.AddBorrower("James") == true, "Test 11: Add Borrower James to Tool 1");
            Assert(tool.AddBorrower("Kevin") == true, "Test 12: Add Borrower Kevin to Tool 1");
            Assert(tool.AddBorrower("Dan") == true, "Test 13: Add Borrower Dan to Tool 1");
            Assert(tool4.AddBorrower("Ben") == true, "Test 14: Add Borrower Ben to Tool 4");

            Assert(tool.SearchBorrower("James") == true, "Test 15: Search Borrower James in Tool 1");
            Assert(tool.DeleteBorrower("James") == true, "Test 16: Delete Borrower James from Tool 1");
            Assert(tool.SearchBorrower("James") == false, "Test 17: Search Borrower James after deletion");
            Assert(tool4.SearchBorrower("Ben") == true, "Test 18: Search Borrower Ben in Tool 4");

            Assert(tool.DeleteBorrower("Eden") == false, "Test 19: Delete non-existent Borrower Eden");

            Console.WriteLine("\n==== Extra Tests ====");
            Assert(collection.Search(null) == false, "Test 20: Search for null tool in collection");

            Console.WriteLine("Test 21: Decrease quantity to zero");
            ITool t7 = new Tool("T7", 2);
            bool result7 = t7.DecreaseQuantity(2);
            Assert(result7 == false, "Test 21a: Return should be false");
            Assert(t7.Quantity == 2, "Test 21b: Quantity should remain 2");
            Assert(t7.AvailableQuantity == 2, "Test 21c: Available should remain 2");

            Console.WriteLine("\nTest 22: Decrease quantity below number of borrowers");
            ITool t8 = new Tool("T8", 5);
            t8.AddBorrower("Borrower 1");
            t8.AddBorrower("Borrower 2");
            t8.AddBorrower("Borrower 3");
            t8.AddBorrower("Borrower 4");
            bool result8 = t8.DecreaseQuantity(2);
            Assert(result8 == false, "Test 22a: Return should be false");
            Assert(t8.Quantity == 5, "Test 22b: Quantity should remain 5");
            Assert(t8.AvailableQuantity == 1, "Test 22c: Available should remain 1");

            Console.Write("Test 22d: Expected borrowers: Borrower 1, 2, 3, 4 --> ");
            string[] expectedBorrowers = { "Borrower 1", "Borrower 2", "Borrower 3", "Borrower 4" };
            bool allFound = true;
            foreach (string borrower in expectedBorrowers)
            {
                if (!t8.SearchBorrower(borrower))
                {
                    allFound = false;
                    break;
                }
            }
            Assert(allFound, "Test 22d");

            Console.WriteLine("\nTest 23: Delete multiple borrowers from list of 8");
            ITool t4 = new Tool("T4", 11);
            string[] borrowers = { "A", "B", "C", "D", "E", "F", "G", "H" };
            foreach (var b in borrowers)
            {
                t4.AddBorrower(b);
            }

            bool result1 = t4.DeleteBorrower("C");
            bool result2 = t4.DeleteBorrower("X");
            bool result3 = t4.DeleteBorrower("A");

            Assert(result1 == true, "Test 23a: Delete 'C'");
            Assert(result2 == false, "Test 23b: Delete 'X'");
            Assert(result3 == true, "Test 23c: Delete 'A'");
            Assert(t4.Quantity == 11, "Test 23d: Quantity should remain 11");
            Assert(t4.AvailableQuantity == 5, "Test 23e: Available quantity should be 5");

            Console.WriteLine("\nTest 24: Delete borrower from empty list and test return empty");
            ITool t6 = new Tool("T6", 3);
            ITool t10 = new Tool("T9", 3);
            t10.AddBorrower("Borrower 1");
            bool result9 = t6.DeleteBorrower("Ghost");
            Assert(result9 == false, "Test 24a: Delete borrower from empty list");
            bool result10 = t10.DeleteBorrower("Borrower 1");
            Assert(result10 == true, "Test 24b: Delete 1 borrower");

            Console.WriteLine("\nTest 25: Decrement quantity of tool with borrowers");

            ITool t1 = new Tool("T1", 2);
            t1.AddBorrower("Borrower 1");
            bool result12 = t1.DecreaseQuantity(1);

            Assert(result12 == true, "Test 25a: DecreaseQuantity should return true");
            Assert(t1.Quantity == 1, "Test 25b: Quantity should now be 1");
            Assert(t1.AvailableQuantity == 0, "Test 25c: Available quantity should be 0");
            Assert(t1.SearchBorrower("Borrower 1") == true, "Test 25d: Borrower 1 should still exist");

            Console.WriteLine("\nTest 26: Decrease quantity of tool by a negative number");

            ITool t6v2 = new Tool("T6", 2);
            t6v2.AddBorrower("Borrower 1");
            bool result6 = t6v2.DecreaseQuantity(-10);

            Assert(result6 == false, "Test 26a: DecreaseQuantity should return false for negative input");
            Assert(t6v2.Quantity == 2, "Test 26b: Quantity should remain 2");
            Assert(t6v2.AvailableQuantity == 1, "Test 26c: Available quantity should remain 1");
            Assert(t6v2.SearchBorrower("Borrower 1") == true, "Test 26d: Borrower 1 should still exist");


            Console.WriteLine($"\n==== Test Summary: {passedTests}/{totalTests} tests passed ====");
        }

        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            test();

            stopwatch.Stop();
            var proc = Process.GetCurrentProcess();

            var logEntry = new
            {
                timestamp = DateTime.UtcNow.ToString("o"),
                executionTimeSeconds = stopwatch.Elapsed.TotalSeconds,
                memoryUsageMB = proc.WorkingSet64 / (1024.0 * 1024.0)
            };

            string json = JsonSerializer.Serialize(logEntry);
            File.AppendAllText("metrics.jsonl", json + Environment.NewLine);
            Console.WriteLine($"Saving metrics to: {Path.GetFullPath("metrics.jsonl")}");
        }
    }
}