using System;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Gateway.memory;
using fabiostefani.io.CleanArch.Repository.Factory;
using Xunit;

namespace fabiostefani.io.CleanArch.ApplicationTests.Config
{
    [CollectionDefinition(nameof(PlaceOrderCollection))]
    public class PlaceOrderCollection : ICollectionFixture<PlaceOrderTestsFixture>
    {
        
    }
    public class PlaceOrderTestsFixture : IDisposable
    {
        public IRepositoryFactory RepositoryFactory;
        public IZipCodeCalculatorApi ZipCodeCalculatorApi;
        
        public void PrepareTests()
        {
            RepositoryFactory = new DatabaseRepositoryFactory();                        
            ZipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var orderRepository = RepositoryFactory.CreateOrderRepository();
            Task.FromResult(orderRepository.Clean());
        }

        public PlaceOrderInput CreatePlaceOrderInputCouponValid()
        {
            var input = new PlaceOrderInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });
            return input;
        }

        public PlaceOrderInput CreatePlaceOrderInputCouponExpired()
        {
            var input = new PlaceOrderInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20_EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new PlaceOrderItemInput() { ItemId = "3", Quantity = 3 });            
            return input;
        }

        public void Dispose()
        {
        }
    }
}