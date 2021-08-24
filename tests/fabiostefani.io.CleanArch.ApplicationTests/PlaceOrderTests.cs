using System;
using fabiostefani.io.CleanArch.Application;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.ApplicationTests.Config;
using fabiostefani.io.CleanArch.Gateway.memory;
using fabiostefani.io.CleanArch.Repository.Factory;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests
{
    [Collection(nameof(ClienteCollection))]
    public class PlaceOrderTests
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public PlaceOrderTests(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact()]
        public async void DeveFazerUmPedido()
        {
            var input = new PlaceOrderInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            var repositoryFactory = new DatabaseRepositoryFactory();                        
            var orderRepository = repositoryFactory.CreateOrderRepository();
            await orderRepository.Clean();
            var zipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var placeOrder = new PlaceOrder(repositoryFactory, zipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(5982, output.Total);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCupomExpirado()
        {
            var input = new PlaceOrderInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20_EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            var repositoryFactory = new DatabaseRepositoryFactory();                        
            var orderRepository = repositoryFactory.CreateOrderRepository();
            await orderRepository.Clean();
            var zipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var placeOrder = new PlaceOrder(repositoryFactory, zipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(7400, output.Total);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCalculoDeFrete()
        {
            var input = new PlaceOrderInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20_EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            var repositoryFactory = new DatabaseRepositoryFactory();                        
            var orderRepository = repositoryFactory.CreateOrderRepository();
            await orderRepository.Clean();
            var zipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var placeOrder = new PlaceOrder(repositoryFactory, zipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(310, output.Freight);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCodigoCalculado()
        {
            var issueDate = DateTime.Now;
            var input = new PlaceOrderInput() {IssueDate = issueDate,  Cpf = "778.278.412-36", Coupon = "VALE20_EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            var repositoryFactory = new DatabaseRepositoryFactory();                        
            var orderRepository = repositoryFactory.CreateOrderRepository();
            await orderRepository.Clean();
            var zipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var placeOrder = new PlaceOrder(repositoryFactory, zipCodeCalculatorApi);
            await placeOrder.Execute(input);
            int sequence = await orderRepository.Count() + 1;
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal("202100000002", output.Code);
        }
    }
}