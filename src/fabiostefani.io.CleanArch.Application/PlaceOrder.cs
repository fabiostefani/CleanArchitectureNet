using System;
using System.Collections.Generic;
using System.Linq;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Application
{
    public class PlaceOrder
    {        
        private ZipCodeCalculatorApiMemory ZipCodeCalculatorApi;
        private readonly ICouponRepository _couponRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ZipCodeCalculatorApi _zipCodeCalculatorApi;

        public PlaceOrder(ICouponRepository couponRepository, IItemRepository itemRepository, IOrderRepository orderRepository, ZipCodeCalculatorApi zipCodeCalculatorApi)
        {
            _couponRepository = couponRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _zipCodeCalculatorApi = zipCodeCalculatorApi;            
        }
        public PlaceOrderOutput Execute(PlaceOrderInput input)
        {
            var order = new Order(input.Cpf);
            ProcessOrderItems(input, order);
            ProcessCoupon(input, order);
            _orderRepository.Save(order);
            return new PlaceOrderOutput()
            {
                Total = order.GetTotal(),
                Freight = order.Freight
            };
        }

        private void ProcessOrderItems(PlaceOrderInput input, Order order)
        {
            var distance = _zipCodeCalculatorApi.Calculate(input.ZipCode, "99.999-999"); ;
            input.OrderItems.ForEach(orderItem =>
            {
                var item = _itemRepository.GetById(orderItem.ItemId);
                if (item == null) throw new Exception("Item not Found");
                order.AddItem(orderItem.ItemId, item.Price, orderItem.Quantity);
                order.Freight += FreightCalculator.Calculate(distance, item) * orderItem.Quantity;
            });
        }

        private void ProcessCoupon(PlaceOrderInput input, Order order)
        {
            if (string.IsNullOrEmpty(input.Coupon)) return;
            var coupon = _couponRepository.GetByCode(input.Coupon);
            if (coupon == null) return;
            order.AddCoupon(coupon);
        }
    }
}