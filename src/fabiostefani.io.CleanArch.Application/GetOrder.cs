using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Application
{
    public class GetOrder
    {        
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public GetOrder(IItemRepository itemRepository, IOrderRepository orderRepository)
        {
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;            
        }
        public async Task<GetOrderOutput> Execute(string code)
        {
            var order = await _orderRepository.GetByCode(code);
            if (order == null) throw new Exception($"Order not found by code {code}.");
            var orderItensOutput = new List<GetOrderItemsOutput>();
            foreach (var orderItem in order.OrderItems)
            {
                Item item = await _itemRepository.GetById(orderItem?.ItemId);
                if (item == null) throw new Exception($"Item not found by ID {orderItem.ItemId}.");
                GetOrderItemsOutput orderItemOutput = new GetOrderItemsOutput()
                {
                    ItemDescription = item.Description,
                    Price = orderItem.Price,
                    Quantity = orderItem.Quantity
                };
                orderItensOutput.Add(orderItemOutput);
            }
            return new GetOrderOutput()
            {
                Total = order.GetTotal(),
                Freight = order.Freight,
                Code = order.Code.Value,
                OrderItems = orderItensOutput
            };
        }
    }
}