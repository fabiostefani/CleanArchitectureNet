using System;
using System.Collections.Generic;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf
{
    public class OrderEf
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Cpf { get; set; }        
        public decimal Freight { get; set; }
        public string? CouponCode { get; set; }
        public DateTime IssueDate { get; set; }
        public int Sequence { get; set; }

        public readonly List<OrderItemEf> OrderItems;
        // public IReadOnlyCollection<OrderItem> OrderItems => _items;

    }
}