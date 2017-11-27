using System;
using System.Collections.Generic;
using System.Linq;
using Seguim.Netcore.Store.Domain.StoreContext.Enums;

namespace Seguim.Netcore.Store.Domain.StoreContext.Entities {

    public class Order {

        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order (Customer customer) {
            this.Customer = customer;
            this.Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray(); 
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem orderItem)
        {
            // Valida o item
            // Adiciona ao pedido
            _items.Add(orderItem);
        }

        public void AddDelivery(Delivery delivery)
        {
            // Valida o item
            // Adiciona ao pedido
            _deliveries.Add(delivery);
        }

        // To Place an Order
        public void Place () { }
    }
}