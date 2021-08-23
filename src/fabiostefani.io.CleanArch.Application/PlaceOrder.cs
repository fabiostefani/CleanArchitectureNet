using System;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Application
{
    public class PlaceOrder
    {        
        private readonly ICouponRepository _couponRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IZipCodeCalculatorApi _zipCodeCalculatorApi;

        public PlaceOrder(ICouponRepository couponRepository, IItemRepository itemRepository, IOrderRepository orderRepository, IZipCodeCalculatorApi zipCodeCalculatorApi)
        {
            _couponRepository = couponRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _zipCodeCalculatorApi = zipCodeCalculatorApi;            
        }
        public async Task<PlaceOrderOutput> Execute(PlaceOrderInput input)
        {
            int sequence = _orderRepository.Count() + 1;
            var order = new Order(input.Cpf, input.IssueDate, sequence);
            await ProcessOrderItems(input, order);
            await ProcessCoupon(input, order);
            _orderRepository.Save(order);
            return new PlaceOrderOutput()
            {
                Total = order.GetTotal(),
                Freight = order.Freight,
                Code = order.Code.Value
            };
        }

        private async Task ProcessOrderItems(PlaceOrderInput input, Order order)
        {
            var distance = _zipCodeCalculatorApi.Calculate(input.ZipCode, "99.999-999");
            foreach (var orderItem in input.OrderItems)
            {
                var item = await _itemRepository.GetById(orderItem.ItemId);
                if (item == null) throw new Exception("Item not Found");
                order.AddItem(orderItem.ItemId, item.Price, orderItem.Quantity);
                order.Freight += FreightCalculator.Calculate(distance, item) * orderItem.Quantity;
            }            
        }

        private async Task ProcessCoupon(PlaceOrderInput input, Order order)
        {
            if (string.IsNullOrEmpty(input.Coupon)) return;
            var coupon = await _couponRepository.GetByCode(input.Coupon);
            if (coupon == null) return;
            order.AddCoupon(coupon);
        }
    }
}