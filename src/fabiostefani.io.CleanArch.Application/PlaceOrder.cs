using System;
using System.Collections.Generic;
using System.Linq;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;

namespace fabiostefani.io.CleanArch.Application
{
    public class PlaceOrder
    {
        private List<Coupon> Coupons;
        private List<Order> Orders;
        private List<Item> Items;
        private ZipCodeCalculatorApiMemory ZipCodeCalculatorApi;

        public PlaceOrder()
        {
            Coupons = new List<Coupon>();
            Coupons.Add(new Coupon("VALE-20", 20, DateTime.Now ));
            Coupons.Add(new Coupon("VALE-20-EXPIRED", 20, new DateTime(2020,01,01) ));

            Orders = new List<Order>();
            Items = new List<Item>();
            Items.Add(new Item("1", "Guitarra", 1000, 100, 50, 15, 3));
            Items.Add(new Item("2", "Amplificador", 5000, 50, 50, 50, 22));
            Items.Add(new Item("3", "Cabo", 30, 10, 10, 10, 1));
            ZipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
        }
        public PlaceOrderOutput Execute(PlaceOrderInput input)
        {
            var order = new Order(input.Cpf);
            ProcessOrderItems(input, order);
            ProcessCoupon(input, order);
            Orders.Add(order);
            return new PlaceOrderOutput()
            {
                Total = order.GetTotal(),
                Freight = order.Freight
            };
        }

        private void ProcessOrderItems(PlaceOrderInput input, Order order)
        {
            var distance = ZipCodeCalculatorApi.Calculate(input.ZipCode, "99.999-999");;
            input.OrderItems.ForEach(orderItem =>
            {
                var item = Items.Find(i => i.Id == orderItem.ItemId);
                if (item == null) throw new Exception("Item not Found");
                order.AddItem(orderItem.ItemId, item.Price, orderItem.Quantity);
                order.Freight += FreightCalculator.Calculate(distance, item) * orderItem.Quantity;
            });
        }

        private void ProcessCoupon(PlaceOrderInput input, Order order)
        {
            if (string.IsNullOrEmpty(input.Coupon)) return;            
            var coupon = Coupons.FirstOrDefault(x => x.Code == input.Coupon);
            if (coupon == null) return;            
            order.AddCoupon(coupon);            
        }
    }
}