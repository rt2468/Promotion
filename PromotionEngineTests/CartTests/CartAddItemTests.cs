using System.Linq;
using PromotionEngine.Entities;
using Xunit;

namespace PromotionEngineTests.CartTests
{
	public class CartAddItemTests
	{
		private readonly string _sku = "A";
		private readonly decimal _testUnitPrice = 45m;
		private readonly int _testQuantity = 2;


		[Fact]
		public void NewCartItem_ShouldBeAdded_IfItemNotPresent()
		{
			var cart = new Cart();
			cart.AddItem(_sku, _testUnitPrice, _testQuantity);

			var firstItem = cart.Items.Single();
			Assert.Equal(_sku, firstItem.Sku);
			Assert.Equal(_testUnitPrice, firstItem.UnitPrice);
			Assert.Equal(_testQuantity, firstItem.Quantity);
		}

		[Fact]
		public void QuantityofItem_ShouldBe_Incremented_IfCartItemExists()
		{
			var cart = new Cart();
			cart.AddItem(_sku, _testUnitPrice, _testQuantity);
			cart.AddItem(_sku, _testUnitPrice, _testQuantity);

			var firstItem = cart.Items.Single();
			Assert.Equal(_testQuantity * 2, firstItem.Quantity);
		}
	}
}