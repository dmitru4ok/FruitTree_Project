using System;
using System.IO;

namespace FruitTree_Project
{
    class FruitTree
    {
        private const uint MaxAge = 30;
        private const uint ProsperityAge = 4;

        private string name_;
        private uint age_;
        private double height_;
        private double yield_;

        public double Height { get { return height_; } }
        public double Yield { get { return yield_; } }

        public FruitTree(string name = "", uint age = 0, double height = 0.0, double yield = 0.0)
        {
            name_ = name;
            age_ = (age > 0 && age <= MaxAge) ? age : 0;
            height_ = (height > 0.0 && height <= 25.0) ? height : 0.0;
            if (age_ >= ProsperityAge && (yield > 0))
            {
                yield_ = yield;
            } else
            {
                yield_ = 0.0;
            }
        }

        public override string ToString()
        {
            return $"{name_} of age {age_} and height {height_}. Gives {yield_} kg of fruit per year";
        }

        public static bool operator <(FruitTree left, FruitTree right)
        {
            if (left.yield_ != right.yield_)
            {
                return left.yield_ < right.yield_;
            }
            else
            {
                return left.height_ < right.height_;
            }
        }

        public static bool operator >(FruitTree left, FruitTree right)
        {
            if (left.yield_ != right.yield_)
            {
                return left.yield_ > right.yield_;
            }
            else
            {
                return left.height_ > right.height_;
            }
        }

        public override bool Equals(object tree)
        {
            if (tree != null && tree.GetType() == typeof(FruitTree))
            {
                return (this.yield_ == ((FruitTree)tree).Yield) && this.height_ == ((FruitTree)tree).Height;
            }
            return false;
        }

        public static bool operator != (FruitTree left, FruitTree right)
        {
            return (left.yield_ != right.yield_) ? true : left.height_ != right.height_;
        }

        public static bool operator ==(FruitTree left, FruitTree right)
        {
            return (left.yield_ == right.yield_) ? left.height_ == right.height_ : false;
        }

        private void UpdateCharacteristics(uint current)
        {
            if (age_ < ProsperityAge && current >= ProsperityAge)
            {
               yield_ = 1.0;
               for(uint k = ProsperityAge; k <= current; ++k)
               {
                    yield_ += yield_ / 1.5;
                    yield_ = Math.Round(yield_, 2);
                }
            } 
            else
            {
                for (uint k = age_; k < current; ++k)
                {
                    yield_ += yield_ / 1.5;
                    yield_ = Math.Round(yield_, 2);
                }
            }
            height_ = Math.Round(height_ + (current - age_) * 0.3, 2);
        }

        public static double operator +(FruitTree left, FruitTree right)
        {
            return left.yield_ + right.yield_;
        }

        public void AddYears(uint param = 1)
        {
            if (param != 0 && param + age_ < MaxAge)
            {
                UpdateCharacteristics(age_ + param);
                age_ += param;
            }
        }

        public double GetProductivity()
        {
            return yield_;
        }

        public void ReadFromConsole(FruitTree myClass)
        {
            Console.Write("Enter name of tree: ");
            string inputName = Console.ReadLine();
            myClass.name_ = inputName;
            Console.Write("Enter age of tree: ");
            string inputAge = Console.ReadLine();
            uint age;
            Console.Write("Enter height of tree: ");
            string inputHeight = Console.ReadLine();
            double height;
            Console.Write("Enter yield of tree: ");
            string inputYield = Console.ReadLine();
            double yield;
            if (uint.TryParse(inputAge, out age))
            {
                myClass.age_ = age;
            }
            else
            {
                throw new InvalidCastException("Input is not a valid integer.");
            }
            if (double.TryParse(inputHeight, out height))
            {
                myClass.height_ = height;
            }
            else
            {
                throw new InvalidCastException("Input is not a valid double.");
            }
            if (double.TryParse(inputYield, out yield))
            {
                myClass.yield_ = yield;
            }
            else
            {
                throw new InvalidCastException("Input is not a valid double.");
            }
        }
    }
}
