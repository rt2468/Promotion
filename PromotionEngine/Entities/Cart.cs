using System;
using System.Collections.Generic;

namespace PromotionEngine.Entities
{
	public class Cart
	{
		private readonly List<CartItem> _items = new List<CartItem>();
		public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

		public void AddItem(string sku, decimal testUnitPrice, int testQuantity)
		{
			throw new NotImplementedException();
		}
	}
}
