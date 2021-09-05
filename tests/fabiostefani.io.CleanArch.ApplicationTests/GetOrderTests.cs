using System;
using fabiostefani.io.CleanArch.Application;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.ApplicationTests.Config;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Gateway.memory;
using fabiostefani.io.CleanArch.Repository.Factory;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests
{
    [Collection(nameof(PlaceOrderCollection))]
    public class GetOrderTests
    {
        private readonly PlaceOrderTestsFixture _placeOrderTestsFixture;        

        public GetOrderTests(PlaceOrderTestsFixture PlaceOrderTestsFixture)
        {
            _placeOrderTestsFixture = PlaceOrderTestsFixture;
            _placeOrderTestsFixture.PrepareTests();            
        }

        [Fact()]
        
        public async void DeveRetornarOsDadosDoPedido()
        {
            PlaceOrderInput input = _placeOrderTestsFixture.CreatePlaceOrderInputCouponValid();
            var placeOrder = new PlaceOrder(_placeOrderTestsFixture.RepositoryFactory, _placeOrderTestsFixture.ZipCodeCalculatorApi);
            PlaceOrderOutput output = await placeOrder.Execute(input);
            var getOrder = new GetOrder(_placeOrderTestsFixture.RepositoryFactory);
            var orderOutput = await getOrder.Execute(output.Code);
            Assert.Equal(5982, orderOutput.Total);
            Assert.Equal(1054.5m, orderOutput.Taxes);
        }
    }
}