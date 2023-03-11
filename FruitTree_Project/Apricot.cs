using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTree_Project
{
    public class Apricot: FruitTree
    {
        private bool freezing;

        public Apricot(uint age = 0, double height = 0.0, double yield = 0.0): base("Apricot", age, height, yield)
        {
            freezing = false;
        }

        public override double Yield
        {
            get
            {
                return (freezing)? 0.8 * base.Yield: base.Yield;
            }
        }

        public void AddYears(bool ifFreezed, uint param = 1)
        {
            base.AddYears(param);
            freezing = ifFreezed;
        }

    }
}
