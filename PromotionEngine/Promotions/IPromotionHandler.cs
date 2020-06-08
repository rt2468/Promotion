using PromotionEngine.Entities;

namespace PromotionEngine.Promotions
{
	public interface IPromotionHandler
	{
		IPromotionHandler SetNext(IPromotionHandler promotionHandler);

		Cart Handle(Cart cart);
	}
}
