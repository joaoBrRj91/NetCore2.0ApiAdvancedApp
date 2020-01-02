using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;
using JohnStore.Domain.StoreContext.Enums;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {

        protected Order() { }
        public Order(Customer customer)
        {
            Customer = customer;

            Items = new List<OrderItem>();
            Deliveries = new List<Delivery>();
        }

        public string Number { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public EOrderStatus Status { get; protected set; }
        public Customer Customer { get; protected set; }
        protected ICollection<OrderItem> Items { get; set; }
        protected ICollection<Delivery> Deliveries { get; set; }


        #region  Set/Get Elements of the Collections
        //TODO : Criar um base entity que tera o Id da entidade e métodos genericos de adição e retorno da coleção
        public void AddItem(Product product, decimal quantity)
        {
            //Valida Item
            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "A quantidade informada é inferior ao estoque do produto.");
            //Adiciona ao pedido
            var orderItem = new OrderItem(quantity, product);

        }

        public List<OrderItem> GetOrderItens()
        {
            var orderItens = new List<OrderItem>();

            foreach (var item in Items)
                orderItens.Add(new OrderItem(item.Quantity,item.Product));
            
            return orderItens;
        }

        public List<Delivery> GetDeliveries()
        {
            var deliveries = new List<Delivery>();

            foreach (var item in Deliveries)
                deliveries.Add(new Delivery(item.EstimatedDeliveryDate));

            return deliveries;
        }
        #endregion 


        #region  Business
        //To Place An Order - Criar um pedido
        public void Place()
        {
            //Criar pedido => Inicializa os dados default das demais propriedades do pedido
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //Validar Pedido
            if (Items.Count == 0)
                AddNotification("Items", "Não existem itens na ordem para ser enviada.");

        }

        //Pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }

        //Enviar um pedido
        public void Ship()
        {
            if (Status != EOrderStatus.Paid)
                AddNotification("Status", "O envio do pedido só pode ser realizado,após o pagamento");

            var itensDeliveries = Items.Count;

            do
            {
                //A cada 5 produtos separa em outrea entrega
                var delivery = new Delivery(estimatedDeliveryDate: DateTime.Now.AddDays(5));
                Deliveries.Add(delivery);
                itensDeliveries -= 5;

            } while (itensDeliveries > 0);

            Deliveries.ToList().ForEach(d => d.Ship());
        }

        //Cancelar um pedido
        public void Cancel()
        {
            if (Deliveries.Any(d => d.Status == EDeliveryStatus.Shipped))
                AddNotification("Status", "Não é possui cancelar o pedido,pois existem itens do pedido que já foram enviados.");

            Status = EOrderStatus.Canceled;
            Deliveries.ToList().ForEach(d => d.Cancel());
        }

        #endregion

    }
}