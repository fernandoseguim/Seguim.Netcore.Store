using System;

namespace Seguim.Netcore.Store.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public DateTime CreateDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string Status { get; set; }
    }
}