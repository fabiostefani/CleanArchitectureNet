using System;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Domain.repository;
using fabiostefani.io.CleanArch.Domain.service.PlaceOrders;
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
            RepositoryFactory = new MemoryRepositoryFactory();                        
            ZipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            var orderRepository = RepositoryFactory.CreateOrderRepository();
            Task.FromResult(orderRepository.Clean());
            IStockEntryRepository stockEntryRepository = RepositoryFactory.CreateStockEntryRepository();
            Task.FromResult(stockEntryRepository.Clean());
        }

        public OrderCreatorInput CreatePlaceOrderInputCouponValid()
        {
            var input = new OrderCreatorInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20", ZipCode = "11.111-111" };
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "3", Quantity = 3 });
            return input;
        }

        public OrderCreatorInput CreatePlaceOrderInputCouponExpired()
        {
            var input = new OrderCreatorInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20_EXPIRED", ZipCode = "11.111-111" };
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "1", Quantity = 2 });
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "2", Quantity = 1 });
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "3", Quantity = 3 });            
            return input;
        }

        public OrderCreatorInput CreatePlaceOrderInputQuantityOutOfStock()
        {
            var input = new OrderCreatorInput() { IssueDate = DateTime.Now, Cpf = "778.278.412-36", Coupon = "VALE20", ZipCode = "11.111-111" };
            input.OrderItems.Add(new OrderCreatorItemInput() { ItemId = "1", Quantity = 12 });            
            return input;
        }

        public void Dispose()
        {
        }
    }
}