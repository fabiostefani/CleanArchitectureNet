using System;
using System.Collections.Generic;

namespace fabiostefani.io.CleanArch.Application.Dtos
{
    public class PlaceOrderInput
    {
        public string Cpf { get; set; }
        public string Coupon { get; set; }
        public string ZipCode { get; set; }
        public DateTime IssueDate { get; set; }
        public List<PlaceOrderItemInput> OrderItems { get; set; }
        public PlaceOrderInput()
        {
            OrderItems = new List<PlaceOrderItemInput>();
            Cpf = string.Empty;
            Coupon = string.Empty;
            ZipCode = string.Empty;
        }
    }

    public class PlaceOrderItemInput
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public PlaceOrderItemInput()
        {
            ItemId = string.Empty;
        }
    }
}