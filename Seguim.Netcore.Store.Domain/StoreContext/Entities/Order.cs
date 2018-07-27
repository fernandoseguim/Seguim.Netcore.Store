using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Seguim.Netcore.Store.Domain.StoreContext.Enums;

namespace Seguim.Netcore.Store.Domain.StoreContext.Entities {

    public class Order : Notifiable
	{
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order (Customer customer) 
		{
            this.Customer = customer;
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

		public void AddItem(Product product, decimal quantity)
        {
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"The product {product.Title} there is not {quantity} items into stock");
            
            var item = new OrderItem(product, quantity);
            _items.Add(item);            
        }
                
        public void AddDelivery(Delivery delivery)
        {
            // Valida o item
            // Adiciona ao pedido
            _deliveries.Add(delivery);
        }

        // To Place an Order
        public void Place ()
		{
			if(_items.Count == 0)
			{
				AddNotification("Order", "This order has no items");
			}
			this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
		}

		public void Pay()
		{
			Status = EOrderStatus.Paid;
			
		}

		public void Ship()
		{
			Status = EOrderStatus.Shipped;
			var deliveries = new List<Delivery>
			{
				new Delivery(DateTime.Now.AddDays(5))
			};
			var count = 1;

			foreach (var item in _items)
			{
				if(count == 5)
				{
					count = 1;
					deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
				}
				count++;
			}

			deliveries.ForEach(delivery => delivery.Ship());
			deliveries.ForEach(delivery => _deliveries.Add(delivery));
		}

		public void Cancel()
		{
			Status = EOrderStatus.Canceled;
			_deliveries.ToList().ForEach(delivery => delivery.Cancel());
		}

    }
}