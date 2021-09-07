using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Domain.service;
using fabiostefani.io.CleanArch.Domain.service.PlaceOrders;

namespace fabiostefani.io.CleanArch.Application
{
    public class PlaceOrder
    {
        private readonly IZipCodeCalculatorApi _zipCodeCalculatorApi;
        private readonly IRepositoryFactory _repositoryFactory;

        public PlaceOrder(IRepositoryFactory repositoryFactory, IZipCodeCalculatorApi zipCodeCalculatorApi)
        {
            _repositoryFactory = repositoryFactory;
            _zipCodeCalculatorApi = zipCodeCalculatorApi;            
        }
        public async Task<PlaceOrderOutput> Execute(OrderCreatorInput input)
        {
            var orderCreator = new OrderCreator(_repositoryFactory, _zipCodeCalculatorApi);
            var order = await orderCreator.Execute(input);
            return new PlaceOrderOutput()
            {
                Total = order.GetTotal(),
                Freight = order.Freight,
                Code = order.Code.Value,
                Taxes = order.Taxes
            };
        }
    }
}