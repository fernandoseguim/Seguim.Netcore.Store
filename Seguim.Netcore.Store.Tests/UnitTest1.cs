using Seguim.Netcore.Store.Domain.StoreContext.Entities;
using Seguim.Netcore.Store.Domain.StoreContext.ValueObjects;
using System;
using Xunit;

namespace Seguim.Netcore.Store.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
			var name = new Name("Fernando", "Seguim");
			var document = new Document("15179188636");
			var email = new Email("fernando.seguim@gmail.com");
			var customer = new Customer(name, document, email, "11982646822");

			var mouse = new Product("Mouse", "Mouse cor de rosa", "imagem-mouse.png", 50.00M, 10);
			var teclado = new Product("Teclado", "Teclado cor de rosa", "imagem-teclado.png", 150.00M, 10);
			var impressora = new Product("Impressora", "Impressora multi-funcional", "imagem-impressora.png", 350.00M, 10);
			var cadeira = new Product("Cadeira", "Cadeira cor de rosa", "imagem-cadeira.png", 450.00M, 10);

			var order = new Order(customer);
			//order.AddItem(new OrderItem(mouse, 5));
			//order.AddItem(new OrderItem(teclado, 5));
			//order.AddItem(new OrderItem(impressora, 5));
			//order.AddItem(new OrderItem(cadeira, 5));

			order.Place();

			//Valida o pedido
			var valid = order.Valid;

			order.Pay();

			order.Ship();

			order.Cancel();

		}
    }
}
