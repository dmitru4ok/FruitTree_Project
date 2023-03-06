using System;


namespace FruitTree_Project
{
    class Program
    {
        static void Main()
        {
            FruitTree a = new FruitTree("Apple", 3, 4.5, 0.0);
            FruitTree b = new FruitTree("Apple", 3, 4.9, 0.0);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine("____UPDATE___");
            Console.WriteLine(a < b);
            Console.WriteLine(a > b);
            a.AddYears(1);
            a.AddYears(1);
            a.AddYears(1);
            a.AddYears(1);
            a.AddYears(1);
            a.AddYears(1);
            a.AddYears(1);
            a.AddYears(1);
            Console.WriteLine(a);
            b.AddYears(4);
            b.AddYears(4);
            Console.WriteLine(b);
            Console.WriteLine(a + b);
            Console.WriteLine(a == b);
            Console.WriteLine(a != b);
            FruitTree c = new FruitTree("Orange", 2, 4.0, 0.0);
            FruitTree d = new FruitTree("Coconut", 3, 4.0, 0.0);
            FruitTree[] fruitTreeArray = { a, b, c, d };
            foreach(FruitTree fruitTree in fruitTreeArray)
            {
                Console.WriteLine(fruitTree);
            }
            Console.WriteLine(a.Equals(b));
            FruitTree e = new FruitTree();
            e.ReadFromConsole(e);
            Console.WriteLine(e);
            Console.ReadLine();
        }
    }
}
