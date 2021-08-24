using System;
using fabiostefani.io.CleanArch.Application;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.ApplicationTests.Config;
using fabiostefani.io.CleanArch.Gateway.memory;
using fabiostefani.io.CleanArch.Repository;
using fabiostefani.io.CleanArch.Repository.database.ef;
using fabiostefani.io.CleanArch.Repository.Repository.Database;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests
{    
    [Collection(nameof(ClienteCollection))]
    public class GetOrderTests
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public GetOrderTests(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact()]
        
        public async void DeveRetornarOsDadosDoPedido()
        {
            var input = new PlaceOrderInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            var couponRepository = new CouponRepositoryDatabase(new EfDataBase());
            var itemRepository = new ItemRepositoryDatabase(new EfDataBase());
            var orderRepository = new OrderRepositoryDatabase(new EfDataBase());            
            await orderRepository.Clean();
            var zipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var placeOrder = new PlaceOrder(couponRepository, itemRepository, orderRepository, zipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            var getOrder = new GetOrder(itemRepository, orderRepository);
            var orderOutput = await getOrder.Execute(output.Code);
            Assert.Equal(5982, orderOutput.Total);
        }
    }
}