using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Models;

namespace ProductWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductDbContext _context;

		public ProductController(ProductDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			return Ok(_context.Products);
		}

		[HttpGet("{productId:int}")]
		public async Task<ActionResult<Product>> GetById(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult> Create(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> Update(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{productId:int}")]
		public async Task<ActionResult> Delete(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
