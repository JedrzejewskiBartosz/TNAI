using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNAI.Dto.Catrgories;
using TNAI.Model.Entities;
using TNAI.Repository.Orders;
using TNAI.Repository.Products;

namespace TNAI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _orderRepository.GetAllOrdersAsync();
            if (!order.Any()) return NotFound();

            return Ok(order);
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] OrderInputDto order)
        {
            if (order == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newOrder = new Order()
            {
                Name = order.Name,
            };

            var result = await _orderRepository.SaveOrderAsync(newOrder);
            if (!result) throw new Exception("ERROR save");

            return Ok(newOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderInputDto order)
        {
            if (order == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingProduct = await _orderRepository.GetOrderByIdAsync(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = order.Name;

            var result = await _orderRepository.SaveOrderAsync(existingProduct);
            if (!result) throw new Exception("ERROR upt");

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _orderRepository.GetOrderByIdAsync(id);
            if (existingProduct == null) return NotFound();

            var result = await _orderRepository.DeleteOrderAsync(id);
            if (!result) throw new Exception("ERROR del");

            return Ok();
        }
    }
}
