using System;
using System.Collections.Generic;
using Seguim.Netcore.Store.Domain.StoreContext.Enums;

namespace Seguim.Netcore.Store.Domain.StoreContext.Entities {

    public class Order {
        public Order (Customer customer) {
            this.Customer = customer;
            this.Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            Items = new List<OrderItem>();
            Deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }
        public IReadOnlyCollection<Delivery> Deliveries { get; private set; }

        public void AddItem(OrderItem orderItem)
        {
            // Valida o item
            // Adiciona ao pedido
        }

        // To Place an Order
        public void Place () { }
    }
}