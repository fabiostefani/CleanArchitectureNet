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
            var input = new PlaceOrderInput() { Cpf = "778.278.412-36", Coupon = "VALE-20" };
            input.Items.Add(new PlaceOrderItemInput() { Description = "Guitarra", Price = 1000, Quantity = 2 });
            input.Items.Add(new PlaceOrderItemInput() { Description = "Amplificador", Price = 5000, Quantity = 1 });
            input.Items.Add(new PlaceOrderItemInput() { Description = "Cabo", Price = 30, Quantity = 3 });
            PlaceOrder placeOrder = new PlaceOrder();
            PlaceOrderOutput output = placeOrder.Execute(input);
            Assert.Equal(5672, output.Total);

            // var order = new Order(cpf);
            // order.AddItem("Guitarra", 1000, 2);
            // order.AddItem("Amplificador", 5000, 1);
            // order.AddItem("Cabo", 30, 3);
            // order.AddCoupon(new Coupon("VALE-20",20));
            
        }
    }
}