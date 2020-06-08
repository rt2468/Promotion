namespace PromotionEngine.Entities
{
	public class CartItem 
	{

		public decimal UnitPrice { get; private set; }
		public int Quantity { get; private set; }
		public string Sku { get;  set; }
		public decimal Price { get; private set; }
		
		public CartItem(string sku, int quantity, decimal unitPrice)
		{
			Sku = sku;
			Quantity = quantity;
			UnitPrice = unitPrice;
			Price = unitPrice * Quantity;
		}

		public void AddQuantity(int quantity)
		{
			Quantity += quantity;
		}

		public void SetNewQuantity(int quantity)
		{
			Quantity = quantity;
		}
		public void SetPrice(decimal price)
		{
			Price = price;
		}
	}
}
