using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductWebApi.Models
{
	[Table("product")]
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("product_id")]
		public int ProductId { get; set; }

		[Column("product_name")]
		public string ProductName { get; set; }

		[Column("product_code")]
		public string ProductCode { get; set; }

		[Column("product_price")]
		public double ProductPrice { get; set; }
	}
}
