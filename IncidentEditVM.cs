namespace SportsPro.Models
{
    public class IncidentEditVM
    {
        public List<Customer> customers { get; set; }
        public List<Product> products { get; set; }
        public List<Technician> technicianes { get; set; }

        public Incident currentIncident { get; set; }
        public string activeUse { get; set; }

        public string CheckActiveUse(string c) =>
            c.ToLower() == activeUse.ToLower() ? "Edit" : "Add";

    }
}
