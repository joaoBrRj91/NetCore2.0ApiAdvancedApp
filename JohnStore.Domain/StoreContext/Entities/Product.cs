namespace JohnStore.Domain.StoreContext.Entities
{
    public class Product
    {
        public Product(
                string title,
                string description,
                string image,
                decimal price,
                int quantityOnHand)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Image { get; protected set; }
        public decimal Price { get; protected set; }
        public int QuantityOnHand { get; protected set; }

        public override string ToString() => $"{Title}";

    }
}