using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Repository.database;
using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using fabiostefani.io.CleanArch.Repository.database.Ef.ModelEf;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class OrderRepositoryDatabase : IOrderRepository
    {
        private readonly IDatabase Database;

        public OrderRepositoryDatabase(IDatabase database)
        {
           this.Database = database;
        }
        public async Task<int> Count()
        {
            IList<OrderEf> list = await this.Database.All<OrderEf>();            
            return list.Count();
        }

        public async Task<bool> Save(Order order)
        {
            OrderEf orderEf = new OrderEf()
            {
                Code = order.Code.Value,
                CouponCode = order.Coupon?.Code,
                Cpf = order.Cpf.Inscricao,
                Freight = order.Freight,
                IssueDate = order.IssueDate,
                Sequence = order.Sequence,
                Taxes = order.Taxes
            };            
            await this.Database.Add<OrderEf>(orderEf);            
            foreach (var orderItem in order.OrderItems)
            {
                OrderItemEf orderItemEf = new OrderItemEf()
                {
                    OrderId = orderEf.Id,
                    ItemId = Convert.ToInt32(orderItem.ItemId),
                    Price = orderItem.Price,
                    Quantity = orderItem.Quantity
                };
                await this.Database.Add<OrderItemEf>(orderItemEf);
            }
            return true;
        }

        public async Task Clean()
        {
            IList<OrderEf> orders = await this.Database.All<OrderEf>();
            await this.Database.RemoveRange<OrderEf>(orders);
        }

        public async Task<Order?> GetByCode(string code)
        {
            OrderEf orderData = await this.Database.One<OrderEf>(order => order.Code == code, orderEf => orderEf.OrderItems);
            if (orderData == null) throw new Exception($"Order EF not found by code {code}.");            
            Order order = new Order(orderData.Cpf, orderData.IssueDate, orderData.Sequence);
            foreach (var orderItem in orderData.OrderItems)
            {
                order.AddItem(orderItem.ItemId.ToString(), orderItem.Price, orderItem.Quantity);
            }
            if (!string.IsNullOrEmpty(orderData.CouponCode))
            {
                CoupomEf couponData = await this.Database.One<CoupomEf>(x => x.Code == orderData.CouponCode);
                if (couponData == null) throw new Exception($"Coupom not found by code {orderData.CouponCode}.");
                var coupon = new Coupon(couponData.Code, couponData.Percentage, couponData.ExpireDate);
                order.AddCoupon(coupon);
            }
            order.Freight = orderData.Freight;
            order.Taxes = orderData.Taxes;

            return order;
        }
    }
}