using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }
        [Required(ErrorMessage = "State is required.")]
        public string? State { get; set; }
        [Required(ErrorMessage = "Postal code is required.")]
        public string? PostalCode { get; set; }
		public string? Phone { get; set; } 
        public string? Email { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string? CountryID { get; set; }   // foreign key property
        public Country? Country { get; set; }           // navigation property

        public string FullName => FirstName + " " + LastName;   // read-only property
	}
}