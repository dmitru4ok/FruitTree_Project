using System;


namespace FruitTree_Project
{
    public class AppleTree: FruitTree
    {
        public string Color { get; }

        public override double Yield { 
            get 
            {
                { return (Age % 2 == 0)? base.Yield : 0; }
            } 
        }

        public AppleTree(string color, uint age = 0, double height = 0.0, double yield = 0.0) : base("Apple", age, height, yield)
        {
            Color = color;
        }

        public override string ToString()
        {
            return base.ToString() + $". Apples of color {Color}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
