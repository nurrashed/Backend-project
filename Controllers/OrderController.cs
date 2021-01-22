using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly FilmContext _context;
        private readonly IMapper _mapper;
        public OrderController(FilmContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders(){
            List<Order> orders = await _context.Orders.Include(o =>o.OrderDetails).ToListAsync();

            List<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetOrderById(int id){
            Order found = await _context.Orders.Include(o=>o.OrderDetails).FirstOrDefaultAsync(o=>o.Id == id);

            if(found == null){
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderDTO newOrderDTO){
            Order newOrder = _mapper.Map<Order>(newOrderDTO);
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateOrder", newOrder);
        }
        

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order){
            if(id != order.Id){
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;

            try{
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!OrderExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return Ok(_mapper.Map<OrderDTO>(order));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e=> e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id){
            Order found = await _context.Orders.FindAsync(id);
            if(found == null){
                return NotFound();
            }
            _context.Orders.Remove(found);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
