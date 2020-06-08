using System;
using PromotionEngine.Entities;
using PromotionEngine.Promotions;

namespace PromotionEngine
{
	class Program
	{
		static void Main(string[] args)
		{
			//Sample run
			var cart = new Cart();
			cart.AddItem("A", 50, 3);
			cart.AddItem("B", 30, 5);
			cart.AddItem("C", 20, 1);
			cart.AddItem("D", 15, 1);

			Cart c = PromotionEngineClient.Apply(cart);
			if (c != null)
			{
				var finalPrice = c.GetTotalAmount();
			}
		}
	}
}
