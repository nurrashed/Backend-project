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
    public class CustomerController : ControllerBase
    {
        private readonly FilmContext _context;
        private readonly IMapper _mapper;
        public CustomerController(FilmContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers(){
            List<Customer> customers = await _context.Customers.Include(f =>f.Orders).ToListAsync();

            List<CustomerDTO> customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);

            return Ok(customerDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetCustomerById(int id){
            Customer found = await _context.Customers.Include(f=>f.Orders).FirstOrDefaultAsync(f=>f.Id == id);

            if(found == null){
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerDTO newCustomerDTO){
            Customer newCustomer = _mapper.Map<Customer>(newCustomerDTO);

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            CustomerDTO returnDTO = _mapper.Map<CustomerDTO>(newCustomer);
            return CreatedAtAction("CreateCustomer", returnDTO);
        }
        

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer){
            if(id != customer.Id){
                return BadRequest();
            }
            _context.Entry(customer).State = EntityState.Modified;

            try{
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!CustomerExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e=> e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id){
            Customer found = await _context.Customers.FindAsync(id);
            if(found == null){
                return NotFound();
            }
            _context.Customers.Remove(found);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
