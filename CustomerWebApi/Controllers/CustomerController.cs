using CustomerWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly CustomerDbContext _context;

		public CustomerController(CustomerDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
		{
			return Ok(_context.Customers);
		}

		[HttpGet("{customerId:int}")]
		public async Task<ActionResult<Customer>> GetById(int customerId)
		{
			var customer = await _context.Customers.FindAsync(customerId);
			return Ok(customer);
		}

		[HttpPost]
		public async Task<ActionResult> Create(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> Update(Customer customer)
		{
			_context.Customers.Update(customer);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{customerId:int}")]
		public async Task<ActionResult> Delete(int customerId)
		{
			var customer = await _context.Customers.FindAsync(customerId);
			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
