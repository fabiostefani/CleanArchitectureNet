using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Domain.repository;
using fabiostefani.io.CleanArch.Domain.service.PlaceOrders;

namespace fabiostefani.io.CleanArch.Domain.service
{
    public class OrderCreator
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IZipCodeCalculatorApi _zipCodeCalculatorApi;
        private readonly ITaxTableRepository _taxTableRepository;
        private readonly IStockEntryRepository _stockEntryRepository;

        public OrderCreator(IRepositoryFactory repositoryFactory, IZipCodeCalculatorApi zipCodeCalculatorApi)
        {
            _couponRepository = repositoryFactory.CreateCouponRepository();
            _itemRepository = repositoryFactory.CreateItemRepository();
            _orderRepository = repositoryFactory.CreateOrderRepository();
            _zipCodeCalculatorApi = zipCodeCalculatorApi;
            _taxTableRepository = repositoryFactory.CreateTaxTableRepository();
            _stockEntryRepository = repositoryFactory.CreateStockEntryRepository();
        }
        public async Task<Order> Execute(OrderCreatorInput input)
        {
            int sequence = await _orderRepository.Count() + 1;
            var order = new Order(input.Cpf, input.IssueDate, sequence);
            await ProcessOrderItems(input, order);
            await ProcessCoupon(input, order);
            await _orderRepository.Save(order);
            return order;
        }

        private async Task ProcessOrderItems(OrderCreatorInput input, Order order)
        {
            var distance = _zipCodeCalculatorApi.Calculate(input.ZipCode, "99.999-999");
            var taxCalculator = TaxCalculatorFactory.Create(input.IssueDate);
            foreach (var orderItem in input.OrderItems)
            {
                var item = await _itemRepository.GetById(orderItem.ItemId);
                if (item == null) throw new Exception("Item not Found");
                order.AddItem(orderItem.ItemId, item.Price, orderItem.Quantity);
                order.Freight += FreightCalculator.Calculate(distance, item) * orderItem.Quantity;
                var taxTables = await _taxTableRepository.GetByIdItem(Convert.ToInt32(item.Id));            
                var taxes = taxCalculator.Calculate(item, taxTables);            
                order.Taxes += taxes * orderItem.Quantity;
                var stockEntries = await _stockEntryRepository.GetByIdItem(Convert.ToInt32(item.Id));
                var stockCalculator = new StockCalculator();
                var quantity = stockCalculator.Calculate(stockEntries);
                if (quantity < orderItem.Quantity) throw new Exception("Out of stock");
                await _stockEntryRepository.Save(new StockEntry(Convert.ToInt32(item.Id), "out", orderItem.Quantity, DateTime.Now));
            }            
        }

        private async Task ProcessCoupon(OrderCreatorInput input, Order order)
        {
            if (string.IsNullOrEmpty(input.Coupon)) return;
            var coupon = await _couponRepository.GetByCode(input.Coupon);
            if (coupon == null) return;
            order.AddCoupon(coupon);
        }
    }
}