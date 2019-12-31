using System;
using System.Collections.Generic;
using System.Linq;
using JohnStore.Domain.StoreContext.Enums;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class Order
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
        public void AddItem(OrderItem item)
        {
            //Valida Item
            //Adiciona ao pedido
            Items.Add(item);

        }

        public List<OrderItem> GetOrderItens()
        {
            var orderItens = new List<OrderItem>();
            orderItens.AddRange(Items.ToArray());
            return orderItens;
        }

        public List<Delivery> GetDeliveries()
        {
            var deliveries = new List<Delivery>();
            deliveries.AddRange(Deliveries.ToArray());
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

        }

        //Pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }

        //Enviar um pedido
        public void Ship()
        {

            var itensDeliveries = Items.Count;

            do
            {
                //A cada 5 produtos separa em outrea entrega
                var delivery = new Delivery(estimatedDeliveryDate: DateTime.Now.AddDays(5));
                Deliveries.Add(delivery);
                itensDeliveries -= 5;

            } while (itensDeliveries > 0);

        }

        //Cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            Deliveries.ToList().ForEach(d => d.Cancel());
        }

        #endregion

    }
}