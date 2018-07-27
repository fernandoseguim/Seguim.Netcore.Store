using System;
using Flunt.Notifications;
using Seguim.Netcore.Store.Domain.StoreContext.Enums;

namespace Seguim.Netcore.Store.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            EstimatedDeliveryDate = estimatedDeliveryDate;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

		public void Ship()
		{
			Status = EDeliveryStatus.Shipped;
		}

		public void Cancel()
		{
			Status = EDeliveryStatus.Canceled;
		}
	}
}