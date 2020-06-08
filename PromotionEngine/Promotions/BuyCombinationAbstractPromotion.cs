using System;
using System.Collections.Generic;
using System.Linq;
using Promotion.Entities;
using PromotionEngine.Entities;

namespace PromotionEngine.Promotions
{
	public class BuyCombinationAbstractPromotion : AbstractPromotionHandler
	{
		public override Cart Handle(Cart cart)
		{
			//Should be injected. Hardcoded for brevity.
			var promotions = new List<BuyCombinationItemPromotion>
			{
				new BuyCombinationItemPromotion()
				{
					Sku1= "C",
					Sku2 = "D",
					TotalPrice = 30
				}
			};

			foreach (var promotion in promotions)
			{
				var sku1CartItem =
					cart.Items.FirstOrDefault(x => x.Sku == promotion.Sku1 && !x.IsPromotionApplied);
				var sku2CartItem =
					cart.Items.FirstOrDefault(x => x.Sku == promotion.Sku2 && !x.IsPromotionApplied);

				if (sku1CartItem != null && sku2CartItem != null)
				{
					int promotionEligibleItemsCount = Math.Min(sku1CartItem.Quantity, sku2CartItem.Quantity);

					decimal sku1Price = CalculatePrice(promotionEligibleItemsCount, promotion.TotalPrice, sku1CartItem);
					decimal sku2Price = CalculatePrice(promotionEligibleItemsCount, promotion.TotalPrice, sku2CartItem);
					sku1CartItem.SetPrice(sku1Price);
					sku2CartItem.SetPrice(sku2Price);
				}

			}
			return base.Handle(cart);
		}

		private static decimal CalculatePrice(int promotionEligibleItemsCount, decimal promotionPrice, CartItem cartItem)

		{
			decimal discountedPrice = promotionEligibleItemsCount * (promotionPrice / 2);
			decimal priceWithoutDiscount = (cartItem.Quantity - promotionEligibleItemsCount) * cartItem.UnitPrice;
			return discountedPrice + priceWithoutDiscount;
		}
	}

}
