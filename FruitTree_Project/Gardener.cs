using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTree_Project
{
    public class Gardener
    {
        public string Name { get; set; }

        public Gardener (string name)
        {
            Name = name;
        }

        public void NewProsperityTreeGardener(object sender, EventArgs e)
        {
            FruitTree tree = sender as FruitTree;
            Console.WriteLine("Gardenerr {0}: tree ({1}) has {2} years reached prosperity age", Name, tree.Name, tree.Age);
        }
    }
}
