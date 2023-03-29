using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace FruitTree_Project
{
    public class FruitTreeCollection : IEnumerable
    {
        private List<FruitTree> trees_;

        public FruitTreeCollection()
        {
            trees_ = new List<FruitTree>();
        }

        public void Add(FruitTree tree)
        {
            trees_.Add(tree);
        }

        public IEnumerator GetEnumerator()
        {
            return trees_.GetEnumerator();
        }
        
        public void Remove(FruitTree tree)
        {
            trees_.Remove(tree);
        }
        
        public void Clear()
        {
            trees_.Clear();
            Console.WriteLine("Collection is empty");
        }
        
        public double GetAverageHeight()
        {
            if (trees_.Count == 0)
                return 0;

            double totalHeight = 0;

            foreach (FruitTree tree in trees_)
            {
                totalHeight += tree.Height;
            }

            return totalHeight / trees_.Count;
        }
        
        public double GetAverageYield()
        {
            if (trees_.Count == 0)
                return 0;

            double totalYield = 0;

            foreach (FruitTree tree in trees_)
            {
                totalYield += tree.Yield;
            }

            return totalYield / trees_.Count;
        }
        
        public void SortByHeight()
        {
            trees_.Sort((a, b) => a.Height.CompareTo(b.Height));
        }
        
        public List<FruitTree> GetHealthyTrees()
        {
            List<FruitTree> healthyTrees = new List<FruitTree>();

            foreach (FruitTree tree in trees_)
            {
                if (tree.Age < FruitTree.MaxAge && tree.Yield > 0)
                {
                    healthyTrees.Add(tree);
                }
            }

            return healthyTrees;
        }
    }
}