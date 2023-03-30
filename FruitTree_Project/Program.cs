using System;
using System.Collections;
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
            //Console.WriteLine(a.Equals(b));

            AppleTree FirstAppleTree = new AppleTree("red", 4, 7, 6.0);
            AppleTree SecondAppleTree = new AppleTree("green", 4, 4.5, 2.0);
            AppleTree ThirdAppleTree = new AppleTree("yellow", 3, 1.5, 0.0);

            Apricot FirstApricotTree = new Apricot(5, 6, 9.0);
            Apricot SecondApricotTree = new Apricot(5, 6.5, 8.5);
            Apricot ThirdApricotTree = new Apricot(5, 0.5, 0.0);
            Apricot FourthApricotTree = new Apricot(3, 0.5, 6.0);

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
                FirstAppleTree, SecondAppleTree, ThirdAppleTree, FirstApricotTree, SecondApricotTree, ThirdApricotTree, FourthApricotTree
            };

            Console.WriteLine("FruitTree list: ");
            Console.WriteLine();
            PrintAllTrees(fruitTree);
            Console.WriteLine("\nThe highest tree: ");
            Console.WriteLine(TheHighestTree(fruitTree));

            Console.WriteLine();
            Console.WriteLine("\nThe yieldest tree: ");
            Console.WriteLine(TheYieldiestTree(fruitTree));
            Console.WriteLine();

            Console.WriteLine(AreAllTreesFruitful(fruitTree));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Added one year: ");
            AddFewYearsToList(fruitTree, 1);
            Console.WriteLine();
            PrintAllTrees(fruitTree);

            Console.WriteLine();
            Console.WriteLine("Added two years: ");
            AddFewYearsToList(fruitTree, 2);
            Console.WriteLine();
            PrintAllTrees(fruitTree);

            Console.WriteLine();
            Console.WriteLine("Most productive trees: ");
            Console.WriteLine();
            PrintAllTrees(NMostFruitfulTrees(fruitTree, 3));
            Console.WriteLine();

            Console.WriteLine("Trees with certain height <= 6.9: ");
            PrintAllTrees(TreesWithSomeHeight(fruitTree, 6.9));
            Console.WriteLine();

            FruitTree a = new FruitTree("Apple", 3, 4.5, 0.0);
            FruitTree b = new FruitTree("Apple", 5, 4.5, 0.0);
            FruitTree c = new FruitTree("Orange", 2, 4.0, 0.0);
            FruitTree d = new FruitTree("Coconut", 3, 4.0, 0.0);
            FruitTree[] fruitTreeArray = { a, b, c, d };

            Gardener firstGardener = new Gardener("Alex");
            SubscribeToTree(firstGardener, fruitTreeArray);
            fruitTreeArray[0].AddYears(1);
            fruitTreeArray[2].AddYears(4);
            Console.WriteLine();

            IEnumerator<FruitTree> enumerator = fruitTree.GetEnumerator();

            enumerator.MoveNext();
            FruitTree firstTree = enumerator.Current;
            Console.WriteLine($"First tree: {firstTree.Name}");
            enumerator.MoveNext();
            FruitTree secondTree = enumerator.Current;
            Console.WriteLine($"Second tree: {secondTree.Name}");
            enumerator.MoveNext();
            FruitTree thirdTree = enumerator.Current;
            Console.WriteLine($"Third tree: {thirdTree.Name}");
            enumerator.MoveNext();
            FruitTree fourthTree = enumerator.Current;
            Console.WriteLine($"Fourth tree: {fourthTree.Name}");
            Console.WriteLine();

            PrintAllTreesEnumerable(fruitTreeArray);
            Console.WriteLine();

            FruitTreeCollection treeCollection = new FruitTreeCollection
            {
                SecondAppleTree,
                ThirdAppleTree,
                FirstApricotTree
            };
            treeCollection.Add(FourthApricotTree);
            Console.WriteLine($"Average height in collection is: {treeCollection.GetAverageHeight()}");
            Console.WriteLine($"Average yield in collection is: {treeCollection.GetAverageYield()}");
            Console.WriteLine($"Healthy trees in collection: ");
            PrintAllTreesEnumerable(treeCollection.GetHealthyTrees());
            Console.WriteLine("Sorting by height");
            treeCollection.SortByHeight();
            PrintAllTreesEnumerable(treeCollection);
            Console.WriteLine();
            treeCollection.Clear();
            PrintAllTreesEnumerable(treeCollection);
            Console.WriteLine();

            Console.WriteLine("--------------------------TESTING EVENT MAXAGE--------------------");
            FruitTree e = new FruitTree("Apple", 29, 4.5, 15.0);
            FruitTree f = new FruitTree("Apple", 31, 4.5, 20.0);
            FruitTree g = new FruitTree("Orange", 28, 4.0, 10.0);
            FruitTree k = new FruitTree("Coconut", 6, 4.0, 10.0);
            List<FruitTree> fruitTree2 = new List<FruitTree>(){ e, f, g, k };
            PrintAllTrees(fruitTree2);
            Console.WriteLine("\n");
            AddFewYearsToList(fruitTree2, 2);
            PrintAllTrees(fruitTree2);

            Console.ReadLine();
        }
        static void PrintAllTrees(List<FruitTree> list)
        {
            foreach (FruitTree tree in list)
            {
                Console.WriteLine(tree);
            }
        }
        
        static void PrintAllTreesEnumerable(IEnumerable list)
        {
            foreach (FruitTree tree in list)
            {
                Console.WriteLine(tree);
            }
        }
        
        static FruitTree TheHighestTree(List<FruitTree> list)
        {
            FruitTree max = new FruitTree();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Height > max.Height)
                    max = list[i];
            }
            return max;
        }

        static FruitTree TheYieldiestTree(List<FruitTree> list)
        {
            FruitTree max = new FruitTree();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Yield > max.Yield)
                {
                    max = list[i];
                }
            }
            return max;
        }

        static string AreAllTreesFruitful(List<FruitTree> list)
        {
            if (list.TrueForAll(tree => tree.IsFruitful)) // модерний варіант
            {
                return "All trees are fruitful";
            }
            return "Not all trees are fruitful!";
            //foreach (FruitTree tree in list)
            //{
            //    if (!tree.IsFruitful)
            //    {
            //        return "Not all trees are fruitful!";
            //    }
            //}
            //return "All trees are fruitful!";
        }
        static void AddFewYearsToList(List<FruitTree> list, uint age)
        {
            foreach (FruitTree tree in list)
            {
                if (tree is Apricot apricot)
                {
                    apricot.AddYears(true, age);
                }
                else
                {
                    tree.AddYears(age);
                }
            }
        }

        static List<FruitTree> NMostFruitfulTrees(List<FruitTree> list, int n)
        {
            FruitTree[] ToOperate = new FruitTree[list.Count];
            list.CopyTo(ToOperate);
            for (int i = 0; i < n; ++i)
            {
                int MaxIndex = i;
                for (int j = i + 1; j < ToOperate.Length; ++j)
                {
                    if (ToOperate[j] > ToOperate[MaxIndex])
                        MaxIndex = j;
                }
                FruitTree temp = ToOperate[i];
                ToOperate[i] = ToOperate[MaxIndex];
                ToOperate[MaxIndex] = temp;
            }
            return ToOperate.Take(n).ToList();
            //return ToOperate[..n]; // ідеальне рішення, треба перенести проект на .NET 6.0
        }

        static List<FruitTree> TreesWithSomeHeight(List<FruitTree> list, double height)
        {
            return list.FindAll(x => x.Height <= height);
            //List<FruitTree> newList = new List<FruitTree>();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i].Height <= height)
            //    {
            //        newList.Add(list[i]);
            //    }
            //}

            //return newList;
        }
        static void SubscribeToTree(Gardener gardener, params FruitTree[] trees)
        {
            foreach (FruitTree tree in trees)
            {
                tree.NewProsperityTree += gardener.NewProsperityTreeGardener;
            }
        }
    }
}
