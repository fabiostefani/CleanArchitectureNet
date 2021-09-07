using System;
using fabiostefani.io.CleanArch.Application;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.ApplicationTests.Config;
using fabiostefani.io.CleanArch.Domain.service.PlaceOrders;
using fabiostefani.io.CleanArch.Gateway.memory;
using fabiostefani.io.CleanArch.Repository.Factory;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests
{
    [Collection(nameof(PlaceOrderCollection))]
    public class PlaceOrderTests
    {
        private readonly PlaceOrderTestsFixture _placeOrderTestsFixture;

        public PlaceOrderTests(PlaceOrderTestsFixture PlaceOrderTestsFixture)
        {
            _placeOrderTestsFixture = PlaceOrderTestsFixture;
            _placeOrderTestsFixture.PrepareTests();
        }

        [Fact()]
        public async void DeveFazerUmPedido()
        {
            OrderCreatorInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponValid();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(5982, output.Total);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCupomExpirado()
        {
            OrderCreatorInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponExpired();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(7400, output.Total);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCalculoDeFrete()
        {
            OrderCreatorInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponExpired();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(310, output.Freight);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCodigoCalculado()
        {
            OrderCreatorInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponExpired();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            await placeOrder.Execute(input);
            var orderRepository = _placeOrderTestsFixture.RepositoryFactory.CreateOrderRepository();            
            int sequence = await orderRepository.Count() + 1;
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal("202100000002", output.Code);
        }

        [Fact()]
        public async void DeveFazerUmPedidoCalculandoImposto()
        {
            OrderCreatorInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponValid();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(5982, output.Total);
            Assert.Equal(1054.5m, output.Taxes);
        }

        [Fact()]
        public async Task NaoDeveFazerPedidoDeUmItemSemEstoqueDisponivel()
        {
            OrderCreatorInput input = _placeOrderTestsFixture.CreatePlaceOrderInputQuantityOutOfStock();            
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);            
            Func<Task> action = async () => await placeOrder.Execute(input);
            var ex = await Assert.ThrowsAsync<Exception>(action);
            Assert.Contains("Out of stock", ex.Message);
        }
    }
}