using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Entities
{
	public class Cart
	{
		private readonly List<CartItem> _items = new List<CartItem>();
		public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

		public void AddItem(string sku, decimal unitPrice, int quantity = 1)
		{
			if (!Items.Any(i => i.Sku == sku))
			{
				_items.Add(new CartItem(sku, quantity, unitPrice));
				return;
			}
			var existingItem = Items.FirstOrDefault(i => i.Sku == sku);
			existingItem?.AddQuantity(quantity);
		}

		public decimal GetTotalAmount() =>
			Items.Sum(x => x.Price);
	}
}
