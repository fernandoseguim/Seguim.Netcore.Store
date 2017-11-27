namespace Seguim.Netcore.Store.Domain.StoreContext.Entities {
    public class OrderItem {
        
        public OrderItem (Product product, decimal quantity) {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}