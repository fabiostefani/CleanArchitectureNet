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
        public PlaceOrder()
        {
            Coupons = new List<Coupon>();
            Coupons.Add(new Coupon("VALE-20", 20));

            Orders = new List<Order>();
        }
        public PlaceOrderOutput Execute(PlaceOrderInput input)
        {
            var order = new Order(input.Cpf);
            input.Items.ForEach(x =>
            {
                order.AddItem(x.Description, x.Price, x.Quantity);
            });
            if (!string.IsNullOrEmpty(input.Coupon))
            {
                var coupon = Coupons.FirstOrDefault(x => x.Code == input.Coupon);
                if (coupon != null)
                {
                    order.AddCoupon(coupon);    
                }                
            }
            Orders.Add(order);
            return new PlaceOrderOutput()
            {
                Total = order.GetTotal()
        };
        }
    }
}