using System;
using PromotionEngine.Entities;

namespace PromotionEngine.Promotions
{
	public static class PromotionEngineClient
	{

		public static Cart Apply(Cart cart)
		{
			var rootPromotion = new BuyNItemAbstractPromotion();
			var nextPromotion = new BuyCombinationAbstractPromotion();

			//More promotion types can be added here. 
			//Also, the order in which promotions are applied decided here.

			rootPromotion.SetNext(nextPromotion);
			AbstractPromotionHandler abstractPromotionHandler = rootPromotion;

			return abstractPromotionHandler.Handle(cart);
		}
	}
}
