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
    }
}