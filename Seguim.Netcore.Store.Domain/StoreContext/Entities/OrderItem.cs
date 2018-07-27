using Flunt.Notifications;

namespace Seguim.Netcore.Store.Domain.StoreContext.Entities {
    public class OrderItem : Notifiable
    {
        
        public OrderItem (Product product, decimal quantity) {
            this.Product = product;
            this.Quantity = quantity;

            if(product.QuantityOnHand < quantity)
            {
                AddNotification("Quantity", "Produto fora de estoque");
            }
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}