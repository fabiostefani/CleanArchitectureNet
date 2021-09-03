using System;
using fabiostefani.io.CleanArch.Application;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.ApplicationTests.Config;
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
            PlaceOrderInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponValid();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(5982, output.Total);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCupomExpirado()
        {
            PlaceOrderInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponExpired();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(7400, output.Total);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCalculoDeFrete()
        {
            PlaceOrderInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponExpired();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal(310, output.Freight);
        }

        [Fact()]
        public async void DeveFazerUmPedidoComCodigoCalculado()
        {
            PlaceOrderInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponExpired();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            await placeOrder.Execute(input);
            var orderRepository = _placeOrderTestsFixture.RepositoryFactory.CreateOrderRepository();            
            int sequence = await orderRepository.Count() + 1;
            PlaceOrderOutput output = await placeOrder.Execute(input);
            Assert.Equal("202100000002", output.Code);
        }
    }
}