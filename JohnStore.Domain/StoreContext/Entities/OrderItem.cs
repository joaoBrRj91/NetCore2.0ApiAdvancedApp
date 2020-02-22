using FluentValidator;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "A quantidade informada é inferior ao estoque do produto.");

            product.DecresedQuantity(quantity);
        }

        public decimal Price { get;  protected set; }
        public int Quantity { get; protected set; }
        public Product Product { get; protected set; }

    }
}