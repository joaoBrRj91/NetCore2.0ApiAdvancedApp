using FluentValidator;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(decimal quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
            Price = product.Price;
        }

        public decimal Price { get;  protected set; }
        public decimal Quantity { get; protected set; }
        public Product Product { get; protected set; }

    }
}