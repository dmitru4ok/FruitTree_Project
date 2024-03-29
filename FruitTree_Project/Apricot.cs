﻿using System;


namespace FruitTree_Project
{
    public class Apricot : FruitTree
    {
        private bool freezing;

        public Apricot(uint age = 0, double height = 0.0, double yield = 0.0) : base("Apricot", age, height, yield)
        {
            freezing = false;
        }

        public override uint Age
        {
            get
            {
                double result = (freezing ? 0.8 * base.Yield : base.Yield);
                if (result > 0)
                {
                    OnYieldReached(EventArgs.Empty);
                }
                else if (age_ > MaxAge) OnAgeReached(EventArgs.Empty);
                return age_;
            }
        }

        public void AddYears(bool ifFreezed, uint param = 1)
        {
            base.AddYears(param);
            freezing = ifFreezed;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
