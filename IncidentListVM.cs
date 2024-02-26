namespace SportsPro.Models
{
    public class IncidentListVM
    {
        public List<Incident> Incidents { get; set; }
        public string ActiveFilter { get; set; } = "All";

        public string CheckActiveFilter(string c) =>
            c.ToLower() == ActiveFilter.ToLower() ? "All" : "";


    }
}
