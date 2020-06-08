using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Entities
{

	public class BuyNItemPromotion
	{
		public string Sku { get; set; }
		public int RequiredQuantity { get; set; }
		public decimal TotalPrice { get; set; }

	}
}
