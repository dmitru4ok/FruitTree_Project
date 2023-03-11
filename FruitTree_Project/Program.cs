using System;


namespace FruitTree_Project
{
    class Program
    {
        static void Main()
        {

            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine("____UPDATE___");
            //Console.WriteLine(a < b);
            //Console.WriteLine(a > b);
            //a.AddYears(1);
            //a.AddYears(1);
            //a.AddYears(1);
            //a.AddYears(1);
            //a.AddYears(1);
            //a.AddYears(1);
            //a.AddYears(1);
            //a.AddYears(1);
            //Console.WriteLine(a);
            //b.AddYears(4);
            //b.AddYears(4);
            //Console.WriteLine(b);
            //Console.WriteLine(a + b);
            //Console.WriteLine(a == b);
            //FruitTree e = new FruitTree();
            //e.ReadFromConsole(e);
            //Console.WriteLine(e);
            //Console.WriteLine(a != b);



            FruitTree a = new FruitTree("Apple", 3, 4.5, 0.0);
            FruitTree b = new FruitTree("Apple", 1, 4.5, 0.0);
            FruitTree c = new FruitTree("Orange", 2, 4.0, 0.0);
            FruitTree d = new FruitTree("Coconut", 3, 4.0, 0.0);
            FruitTree[] fruitTreeArray = { a, b, c, d };
            foreach(FruitTree fruitTree in fruitTreeArray)
            {
                Console.WriteLine(fruitTree);
            }
            //Console.WriteLine(a.Equals(b));
            FruitTree A = new AppleTree("red", 3, 4.5, 0.0);
            Console.WriteLine(A);
            A.AddYears(1);
            Console.WriteLine(A);
         
            Console.WriteLine(A);
            Console.WriteLine(A.Yield);
            A.AddYears(1);
            Console.WriteLine(A.Yield);
            Console.WriteLine(A);
            FruitTree A = new Apricot(3, 4.5, 0.0);

            Console.ReadLine();
        }
    }
}
