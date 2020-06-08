using PromotionEngine.Entities;

namespace PromotionEngine.Promotions
{
	public abstract class AbstractPromotionHandler : IPromotionHandler
	{
		private IPromotionHandler _nextPromotionHandler;

		public IPromotionHandler SetNext(IPromotionHandler promotionHandler)
		{
			this._nextPromotionHandler = promotionHandler;
			return promotionHandler;
		}

		public virtual Cart Handle(Cart cart) =>
			this._nextPromotionHandler != null ? 
				this._nextPromotionHandler.Handle(cart) : cart;
	}
}
