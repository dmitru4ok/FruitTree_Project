using System;


namespace FruitTree_Project
{
    public class AppleTree : FruitTree
    {
        public string Color { get; }

        public override uint Age
        {
            get
            {
                double result = (age_ % 2 == 0) ? base.Yield : 0;
                if (result > 0)
                {
                    OnYieldReached(EventArgs.Empty);
                }
                return age_;
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

        protected override void TreeYieldReached(object sender, EventArgs e)
        {
            Console.WriteLine("Дерево Яблуко досягло плодоносного віку!");
        }
    }
}
