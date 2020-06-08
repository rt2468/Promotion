using PromotionEngine.Entities;
using Xunit;
using PromotionEngine.Promotions;

namespace PromotionEngineTests.PromotionTests
{
	public class PromotionEngineTests
	{

		[Fact]
		public void PromotionEngine_WhenNoPromotion_ReturnsTotalAmount()
		{
			var cart = new Cart();
			cart.AddItem("A", 50, 1);
			cart.AddItem("B", 30, 1);
			cart.AddItem("C", 20, 1);

			cart = PromotionEngineClient.Apply(cart);

			Assert.Equal(100, cart.GetTotalAmount());
		}

		[Fact]
		public void PromotionEngine_NQuantitiesOfPromotionItemsAreAdded_DiscountShouldBeApplied()
		{
			var cart = new Cart();
			cart.AddItem("A", 50, 5);
			cart.AddItem("B", 30, 5);
			cart.AddItem("C", 20, 1);

			cart = PromotionEngineClient.Apply(cart);

			Assert.Equal(370, cart.GetTotalAmount());
		}

		[Fact]
		public void PromotionEngine_CombinationPromotionItemsAreAdded_DiscountShouldBeApplied()
		{
			var cart = new Cart();
			cart.AddItem("A", 50, 3);
			cart.AddItem("B", 30, 5);
			cart.AddItem("C", 20, 1);
			cart.AddItem("D", 15, 1);

			cart = PromotionEngineClient.Apply(cart);

			Assert.Equal(280, cart.GetTotalAmount());
		}
	}
}
