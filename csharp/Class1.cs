using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class NthMilkIsFree : NthItemIsFree
    {
        protected NthMilkIsFree(int amount) : base(Item.Milk, amount)
        {
        }
    }
    public class ThirdMilkIsFree : NthMilkIsFree
    {
        public ThirdMilkIsFree() : base(3)
        {
        }
    }
    public class NthItemIsFree : IDiscountCalculator
    {
        private readonly Item item;
        private readonly int amount;

        protected NthItemIsFree(Item item, int amount)
        {
            this.item = item;
            this.amount = amount;
        }
            
        public decimal Calculate(IEnumerable<Item> items)
        {
            return item.Price * items.Count(i => i.Equals(item))/amount;
        }
    }

    public class Cart
    {
        private readonly List<IDiscountCalculator> discountCalculators = 
            new List<IDiscountCalculator>();

        public List<Item> Items { get; private set; }

        public Cart()
        {
            this.Items = new List<Item>();
        }

        public void AddItems(Item item, int amount)
        {
            Items.AddRange(Enumerable.Repeat(item, amount));
        }

        public decimal GetTotal()
        {
            var totalWithoutDiscounts = Items.Sum(i => i.Price);
            var totalDiscounts = discountCalculators.Sum(d => d.Calculate(Items));
            return totalWithoutDiscounts - totalDiscounts;
        }

        public void ApplyDiscount(IDiscountCalculator discountCalculator)
        {
            discountCalculators.Add(discountCalculator);
        }
    }

    public interface IDiscountCalculator
    {
        decimal Calculate(IEnumerable<Item> items);
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public static readonly Item Milk = new Item("Milk", 15);

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        protected bool Equals(Item other)
        {
            return string.Equals(Name, other.Name) && Price == other.Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Price.GetHashCode();
            }
        }
    }
}
