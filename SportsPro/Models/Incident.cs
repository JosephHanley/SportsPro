using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Incident
    {
		public int IncidentID { get; set; }
		[Required(ErrorMessage = "Title is required.")]
		public string? Title { get; set; }
		[Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        public DateTime? DateOpened { get; set; } = DateTime.Now;
        public DateTime? DateClosed { get; set; }

		[Required(ErrorMessage = "CustomerID is required")]
		public int? CustomerID { get; set; }                   // foreign key property
		public Customer? Customer { get; set; }       // navigation property

		[Required(ErrorMessage = "ProductID is required")]
		public int? ProductID { get; set; }                    // foreign key property
		public Product? Product { get; set; }         // navigation property

		[Required(ErrorMessage = "TechnicianID is required")]
		public int? TechnicianID { get; set; }                 // foreign key property 
		public Technician? Technician { get; set; }   // navigation property

		
	}
}