using JohnStore.Shared.Entities;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        protected Product() {}

        public Product(
                string title,
                string description,
                string image,
                decimal price,
                int quantityOnHand) : base()
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;

            ValidateEntity();
        }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public string Image { get; protected set; }

        public decimal Price { get; protected set; }

        public int QuantityOnHand { get; protected set; }
        
        public override string ToString() => $"{Title}";

        public void DecresedQuantity(int quantity) => QuantityOnHand -= quantity;

        public override void ValidateEntity()
        {
            if (string.IsNullOrEmpty(Title))
               AddNotification("Title", "Titulo do produto deve ser preenchido");

            if(Price <= 0M)
                AddNotification("Price", "Preço do produto não pode ser menor ou igual a zero");

            if (QuantityOnHand <= 0)
                AddNotification("QuantityOnHand", "Quantidade em estoque do produto não pode ser menor ou igual a zero");

        }

    }

}