using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Technician
    {
		public int TechnicianID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }
    }
}
