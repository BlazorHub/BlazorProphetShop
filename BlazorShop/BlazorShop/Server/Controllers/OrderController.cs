using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Repositories.OrderProductRepository;
using BlazorShop.Server.Data.Repositories.OrderRepository;
using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly BlazorShopContext _context;

        public OrderController(IMapper mapper,
                               IOrderRepository orderRepository,
                               IOrderProductRepository orderProductRepository,
                               BlazorShopContext context)
        {
            _mapper = mapper;
            _context = context;
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _orderRepository.GetAllRequests();

            return Ok(_mapper.Map<List<ManagerOrderItemViewModel>>(requests));
        }

        [HttpGet("byuser/{id}")]
        public async Task<IActionResult> GetAllByUser([FromRoute] int id)
        {
            var orders = await _orderRepository.GetAllByUser(id);
            var newOrders = _mapper.Map<List<CustomerOrderViewModel>>(orders);

            return Ok(newOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleRequest([FromRoute] int id)
        {
            var request = await _orderRepository.GetSingleRequest(id);

            return Ok(_mapper.Map<ManagerOrderViewModel>(request));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(OrderSubmitDTO newOrder)
        {
            Order order = new Order
            {
                CustomerId = newOrder.CustomerId,
                Payment = newOrder.Payment,
                Status = OrderStatus.PENDING,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DiscountPercentage = newOrder.DiscountPercentage
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            List<OrderProduct> orderProducts = new List<OrderProduct>();

            foreach (var item in newOrder.OrderProduct)
            {
                orderProducts.Add(new OrderProduct
                {
                    Quantity = item.Quantity,
                    Value = item.Value,
                    OrderId = order.Id,
                    ProductId = item.ProductId
                });
            }

            _context.OrderProduct.AddRange(orderProducts);
            await _context.SaveChangesAsync();

            return Ok(order.Id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateSingleStatus(UpdateOrderStatusDTO orderToUpdate)
        {
            var existingOrder = await _orderRepository.SingleAsync(o => o.Id == orderToUpdate.Id);
            existingOrder.Status = orderToUpdate.Status;

            _context.Update(existingOrder);
            await _context.SaveChangesAsync();

            return Ok(existingOrder.Id);
        }
    }
}
