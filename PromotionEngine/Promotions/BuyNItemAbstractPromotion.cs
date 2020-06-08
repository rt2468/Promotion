using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Entities;

namespace PromotionEngine.Promotions
{
	public class BuyNItemAbstractPromotion : AbstractPromotionHandler
	{
		public override Cart Handle(Cart cart)
		{
			//Should be injected. Hardcoded for brevity.
			var promotions = new List<Promotion.Entities.BuyNItemPromotion>
			{
				new Promotion.Entities.BuyNItemPromotion()
				{
					Sku = "A",
					RequiredQuantity = 3,
					TotalPrice = 130
				},
				new Promotion.Entities.BuyNItemPromotion()
				{
					Sku = "B",
					RequiredQuantity = 2,
					TotalPrice = 45
				}
			};

			foreach (var promotion in promotions)
			{
				var itemsInPromotionSku =
					cart.Items
						.FirstOrDefault(x => x.Sku == promotion.Sku
											 && x.IsPromotionApplied == false);

				if (itemsInPromotionSku != null && itemsInPromotionSku.Quantity >= promotion.RequiredQuantity)
				{

					int itemsWithoutPromotion = itemsInPromotionSku.Quantity % promotion.RequiredQuantity;
					int setOfItemGroupsEligibleForPromotion = itemsInPromotionSku.Quantity / promotion.RequiredQuantity;

					decimal totalPrice = setOfItemGroupsEligibleForPromotion * promotion.TotalPrice
									+ itemsWithoutPromotion * itemsInPromotionSku.UnitPrice;

					itemsInPromotionSku.SetPrice(totalPrice);
					itemsInPromotionSku.IsPromotionApplied = true;

				}
			}
			return base.Handle(cart);

		}
	}
}

