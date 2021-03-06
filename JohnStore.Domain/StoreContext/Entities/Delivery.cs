using System;
using JohnStore.Shared.Entities;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        protected Delivery() { }

        public Delivery(DateTime estimatedDeliveryDate) : base()
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = Enums.EDeliveryStatus.Waiting;
        }

        public Enums.EDeliveryStatus Status { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime EstimatedDeliveryDate { get; protected set; }

        public void Ship()
        {
            //Validar envio pedidos
            //Se a data estimada de entrega for no passado não entregar 
            Status = Enums.EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se for entregue não pode ser cancelado
            Status = Enums.EDeliveryStatus.Canceled;
        }

    }
}