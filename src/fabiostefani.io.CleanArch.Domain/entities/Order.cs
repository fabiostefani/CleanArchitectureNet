using System.Linq;
using System;
using System.Collections.Generic;

namespace fabiostefani.io.CleanArch.Domain
{
    public class Order
    {
        public Cpf Cpf { get; private set; }
        public decimal Total { get; private set; }
        public decimal Freight { get; set; }
        public Coupon? Coupon { get; private set; }
        private readonly List<OrderItem> _items;
        public IReadOnlyCollection<OrderItem> OrderItems => _items;
        public Order(string cpf)
        {
            Cpf = new Cpf(cpf);
            if (!Cpf.IsValid()) throw new Exception("Invalid CPF");
            _items = new List<OrderItem>();            
        }

        public void AddItem(string itemId, decimal price, int quantity)
        {
            _items.Add(new OrderItem(itemId, price, quantity));
            Total = GetTotal();
        }

        public decimal GetTotal()
        {
            decimal total = OrderItems.Sum(x => x.GetTotal());            
            if (Coupon != null)
            {
                total -= (total * Coupon.Percentage) / 100;
            }
            total += Freight;
            return total;
        } 

        public void AddCoupon(Coupon coupon)
        {
            if (coupon.IsExpired()) return;            
            Coupon = coupon;
        }
    }
}