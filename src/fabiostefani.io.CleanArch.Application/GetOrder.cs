using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Application.Dtos;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Domain.Factory;

namespace fabiostefani.io.CleanArch.Application
{
    public class GetOrder
    {        
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public GetOrder(IRepositoryFactory repositoryFactory)
        {
            _itemRepository = repositoryFactory.CreateItemRepository();
            _orderRepository = repositoryFactory.CreateOrderRepository();            
        }
        public async Task<GetOrderOutput> Execute(string code)
        {
            var order = await _orderRepository.GetByCode(code);
            if (order == null) throw new Exception($"Order not found by code {code}.");
            List<GetOrderItemsOutput> orderItensOutput = await ProcessOrderItemsOutput(order);
            return new GetOrderOutput()
            {
                Total = order.GetTotal(),
                Freight = order.Freight,
                Code = order.Code.Value,
                OrderItems = orderItensOutput
            };

            async Task<List<GetOrderItemsOutput>> ProcessOrderItemsOutput(Order? order)
            {
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

                return orderItensOutput;
            }
        }
    }
}