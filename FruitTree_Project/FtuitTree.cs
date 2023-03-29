using System;
using System.Collections;
using System.Globalization;

namespace FruitTree_Project
{
    public class FruitTree : IComparable, IFormattable, IEnumerable
    {
        private const uint MaxAge = 30;
        private const uint ProsperityAge = 4;

        private string name_;
        protected uint age_;
        protected double height_;
        protected double yield_;

        public event EventHandler YieldReached;
        public event EventHandler NewProsperityTree;

        public double Height { get { return height_; } }
        public virtual double Yield { get { return yield_; }  set { yield_ = value; } }
        public virtual uint Age { 
            get 
            {   
                if(age_ > ProsperityAge) 
                { OnYieldReached(EventArgs.Empty); }
                return age_; 
            } 
            set
            {
                age_ = value;
            }
        }

        public string Name
        {
            get { return name_; }
            set { name_ = value; }
        }
        public bool IsFruitful { get { return age_ >= ProsperityAge; } }

        public FruitTree(string name = "", uint age = 0, double height = 0.0, double yield = 0.0)
        {
            YieldReached += TreeYieldReached;
            name_ = name;
            age_ = (age > 0 && age <= MaxAge) ? age : 0;
            height_ = (height > 0.0 && height <= 25.0) ? height : 0.0;
            if (age_ >= ProsperityAge && (yield > 0))
            {
                yield_ = yield;
            }
            else
            {
                yield_ = 0.0;
            }
            
        }

        public override string ToString()
        {
            return $"{name_} of age {Age} and height {Height}. Given {Yield} kg of fruit this year";
        }

        public string ToString(string format = "D")
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }


        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format is null) return this.ToString("D", formatProvider);
            string ageStr = age_.ToString(null, formatProvider);
            string yieldStr = yield_.ToString(null, formatProvider);
            string heightStr = height_.ToString(null, formatProvider);
            switch (format)
            {
                case "D": // D stands for DEFAULT
                    return $"{name_} of age {Age} and height {Height}. Given {Yield} kg of fruit this year";
                case "T": // T stands for TABULATED
                    string head = "Name:".PadRight(name_.Length) + "|Age:" +
                        "|Productivity:".PadRight(yieldStr.Length) + "|Height:".PadRight(heightStr.Length);
                    string bottom = name_.ToString().PadRight(5) + $"|{ageStr}".PadRight(5) + $"|{yieldStr}".PadRight(14) + $"|{heightStr}".PadRight(8);
                    return head + '\n' + bottom;
                case "S": // S stands for SHORT
                    return $"N:{name_}| A:{ageStr}| P:{yieldStr}| H:{heightStr}";
                case "P": // P stands for PRETTY
                    //?int maxLen = Math.Max(Math.Max(name_.Length, ageStr.Length), Math.Max(yieldStr.Length, heightStr.Length));
                    int maxLen = 15;
                    return name_.ToString().PadRight(maxLen) + $"|{ageStr}".PadRight(maxLen) + $"|{yieldStr}".PadRight(maxLen)
                        + $"|{heightStr}".PadRight(maxLen);
                default:
                    throw new FormatException();
            }
        }

        public static bool operator <(FruitTree left, FruitTree right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator >(FruitTree left, FruitTree right)
        {
            return left.CompareTo(right) == 1;
        }

        public override bool Equals(object tree)
        {
            if (tree is FruitTree myObj)
            {
                return CompareTo(myObj) == 0;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            return new FruitTreeEnumerator(this);
        }
        
        private class FruitTreeEnumerator : IEnumerator
        {
            private FruitTree tree_;
            private int position_;

            public FruitTreeEnumerator(FruitTree tree)
            {
                tree_ = tree;
                position_ = -1;
            }
            
            public object Current
            {
                get
                {
                    if (position_ == -1 || position_ > 2)
                        throw new InvalidOperationException();
                    switch (position_)
                    {
                        case 0:
                            return tree_.name_;
                        case 1:
                            return tree_.age_;
                        case 2:
                            return tree_.height_;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }
            
            public bool MoveNext()
            {
                if (position_ < 2)
                {
                    position_++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            public void Reset()
            {
                position_ = -1;
            }
        }


        public static bool operator !=(FruitTree left, object right)
        {
            if (left is null && right is null)
            {
                return false;
            }
            else if (!(left is null))
            {
                return !left.Equals(right);
            }
            return true;
        }

        public static bool operator ==(FruitTree left, object right)
        {
            if (left is null && right is null)
            {
                return true;
            }
            else if (!(left is null))
            {
                return left.Equals(right);
            }
            return false;
        }

        private void UpdateCharacteristics(uint current)
        {
            if (age_ < ProsperityAge && current >= ProsperityAge)
            {
                yield_ = 1.0;
                for (uint k = ProsperityAge; k <= current; ++k)
                {
                    yield_ += yield_ / 1.5;
                    yield_ = Math.Round(yield_, 2);
                }
            }
            else
            {
                if (yield_ == 0)
                {
                    yield_ = 1;
                }
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
            return left.Yield + right.Yield;
        }

        public virtual void AddYears(uint param = 1)
        {
            if (param != 0 && param + age_ < MaxAge)
            {
                UpdateCharacteristics(age_ + param);
                age_ += param;
                Console.WriteLine("You added {0} years to {1}", param, this.Name);
                if (age_ >= 4)
                {
                    OnNewProsperityTree(EventArgs.Empty);
                }
            }
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

        public int CompareTo(object obj)
        {
            if (obj is FruitTree conv)
            {
                if (Yield.CompareTo(conv.Yield) == 0)
                {
                    if (Height.CompareTo(conv.Height) == 0)
                        return Age.CompareTo(conv.Age);
                    return Height.CompareTo(conv.Height);
                }
                return Yield.CompareTo(conv.Yield);
            }
            throw new InvalidCastException();
        }

        protected virtual void OnYieldReached(EventArgs e)
        {
            YieldReached?.Invoke(this, e);
        }

        protected virtual void TreeYieldReached(object sender, EventArgs e)
        {
            Console.WriteLine("Дерево досягло плодоносного віку!");
        }
        protected virtual void OnNewProsperityTree(EventArgs e)
        {
            NewProsperityTree?.Invoke(this, e);
        }
    }
}
