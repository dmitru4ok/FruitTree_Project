using System;
using System.Collections.Generic;
using System.Linq;

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
            FruitTree b = new FruitTree("Apple", 5, 4.5, 0.0);
            FruitTree c = new FruitTree("Orange", 2, 4.0, 0.0);
            FruitTree d = new FruitTree("Coconut", 3, 4.0, 0.0);
            FruitTree[] fruitTreeArray = { a, b, c, d };
            //foreach(FruitTree fruitTree in fruitTreeArray)
            //{
            //    Console.WriteLine(fruitTree);
            //}
            
            //Console.WriteLine(a.Equals(b));
            AppleTree FirstAppleTree = new AppleTree("red", 4, 7, 6.0);
            AppleTree SecondAppleTree = new AppleTree("green", 4, 4.5, 2.0);
            AppleTree ThirdAppleTree = new AppleTree("yellow", 3, 1.5, 0.0);

            Apricot FirstApricotTree = new Apricot(5, 6, 9.0);
            Apricot SecondApricotTree = new Apricot(5, 6.5, 8.5);
            Apricot ThirdApricotTree = new Apricot(5, 0.5, 0.0);

            //Console.WriteLine(A);
            //A.AddYears(1);
            //Console.WriteLine(A);

            //Console.WriteLine(A);
            //Console.WriteLine(A.Yield);
            //A.AddYears(1);
            //Console.WriteLine(A.Yield);
            //Console.WriteLine(A);

            //Console.WriteLine(B);
            //B.AddYears(true, 1);
            //Console.WriteLine(B);

            List<FruitTree> fruitTree = new List<FruitTree>()
            {
                FirstAppleTree, SecondAppleTree, ThirdAppleTree, FirstApricotTree, SecondApricotTree, ThirdApricotTree
            };

            foreach (FruitTree tree in fruitTree)
            {
                Console.WriteLine(tree);
            }
            
            Console.WriteLine(TheHighestTree(fruitTree));
            Console.WriteLine(TheYieldiestTree(fruitTree));
            Console.WriteLine(AreAllTreesFruitful(fruitTree));
            AddFewYearsToList(fruitTree, 1);
            Console.WriteLine();
            foreach (FruitTree tree in fruitTree)
            {
                Console.WriteLine(tree);
            }
            AddFewYearsToList(fruitTree, 2);
            Console.WriteLine();
            foreach (FruitTree tree in fruitTree)
            {
                Console.WriteLine(tree);
            }

            Console.WriteLine();
            ThreeMostFruitfulTrees(fruitTree);
            foreach (FruitTree tree in fruitTree)
            {
                Console.WriteLine(tree);
            }
            Console.ReadLine();
        }
        
        static FruitTree TheHighestTree(List<FruitTree> list)
        {
            return list.OrderByDescending( x => x.Height).First();
        }

        static FruitTree TheYieldiestTree(List<FruitTree> list)
        {
            return list.OrderByDescending(x => x.Yield).First();
        }

        static string AreAllTreesFruitful(List<FruitTree> list)
        {
            uint counter = 0;
            foreach (FruitTree tree in list)
            {
                if (tree.Age >= 4)
                {
                    counter++;
                }
            }
            if (counter == list.Count)
            {
                return "All trees are fruitful!";
            }
            return "Not all trees are fruitful!";
        }
        static void AddFewYearsToList(List<FruitTree> list, uint age)
        {
            foreach (FruitTree tree in list)
            {
                if (tree is Apricot)
                {
                    ((Apricot)tree).AddYears(true, age);
                }
                else
                {
                    tree.AddYears(age);
                }
            }
        }

        //static FruitTree ThreeMostFruitfulTrees(List<FruitTree> list)
        //{
        //    List<FruitTree> newList = new List<FruitTree>();
        //    list.Sort((a, b) => b.Yield.CompareTo(a.Yield));
        //    while(newList.Count != 3)
        //    {
        //        foreach (FruitTree tree in list)
        //        {
        //            list.Take(1);
        //        }
        //    }
        //    foreach (FruitTree tree in newList)
        //    {
        //        yield return tree;
        //    } 
        //}
        static List<FruitTree> ThreeMostFruitfulTrees(List<FruitTree> list)
        {
            list.OrderByDescending(x => x.Yield);
            List<FruitTree> newList = new List<FruitTree>() { list[0], list[1], list[2]};

            return newList;
        }
    }
}
