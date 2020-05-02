using JohnStore.Shared.Entities;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {

        protected  OrderItem()  { }

        public OrderItem(int quantity, Product product) :  base()
        {
            Quantity = quantity;
            Product = product;
            Price = product.Price;

            ValidateEntity();
            
        }

        public decimal Price { get;  protected set; }
        public int Quantity { get; protected set; }
        public Product Product { get; protected set; }

        public override void ValidateEntity()
        {
            if (Product.QuantityOnHand < Quantity)
                AddNotification("Quantity", "A quantidade informada é inferior ao estoque do produto.");

            Product.DecresedQuantity(Quantity);
        }
    }
}