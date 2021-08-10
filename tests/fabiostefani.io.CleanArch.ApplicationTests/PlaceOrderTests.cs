using fabiostefani.io.CleanArch.Application;
using fabiostefani.io.CleanArch.Application.Dtos;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests
{
    public class PlaceOrderTests
    {
        [Fact]
        public void DeveFazerUmPedido()
        {
            var input = new PlaceOrderInput() { Cpf = "778.278.412-36", Coupon = "VALE-20", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            PlaceOrder placeOrder = new PlaceOrder();
            PlaceOrderOutput output = placeOrder.Execute(input);
            Assert.Equal(5982, output.Total);
        }

        [Fact]
        public void DeveFazerUmPedidoComCupomExpirado()
        {
            var input = new PlaceOrderInput() { Cpf = "778.278.412-36", Coupon = "VALE-20-EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            PlaceOrder placeOrder = new PlaceOrder();
            PlaceOrderOutput output = placeOrder.Execute(input);
            Assert.Equal(7400, output.Total);
        }

        [Fact]
        public void DeveFazerUmPedidoComCalculoDeFrete()
        {
            var input = new PlaceOrderInput() { Cpf = "778.278.412-36", Coupon = "VALE-20-EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            PlaceOrder placeOrder = new PlaceOrder();
            PlaceOrderOutput output = placeOrder.Execute(input);
            Assert.Equal(310, output.Freight);
        }
    }
}