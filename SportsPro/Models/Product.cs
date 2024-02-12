using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class Product
    {
		public int ProductID { get; set; }
        [Required(ErrorMessage = "Product ID is required")]
        public string? ProductCode { get; set; }
        [Required(ErrorMessage = "Product code is required")]
        public string? Name { get; set; }
		[Column(TypeName = "decimal(8,2)")]
		public decimal? YearlyPrice { get; set; }
		public DateTime? ReleaseDate { get; set; } = DateTime.Now;
	}
}
