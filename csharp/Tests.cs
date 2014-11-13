using FluentAssertions;
using Xunit;

namespace csharp
{
    public class Class1
    {
        [Fact]
        public void item_should_be_comparable()
        {
            new Item("Milk", 15).Should().Be(Item.Milk);
        }

        [Fact]
        public void new_cart_should_be_empty()
        {
            new Cart().Items.Should().BeEmpty();
        }

        [Fact]
        public void should_calculate_sum_of_all_items()
        {
            var cart = new Cart();
            cart.AddItems(Item.Milk, 3);
            cart.GetTotal().Should().Be(45);
        }

        [Fact]
        public void third_milk_should_be_free()
        {
            var cart = new Cart();
            cart.AddItems(Item.Milk, 3);
            cart.ApplyDiscount(new ThirdMilkIsFree());
            cart.GetTotal().Should().Be(30);
        }
    }
}