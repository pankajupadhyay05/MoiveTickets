using System.ComponentModel.DataAnnotations;

namespace MoiveTickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; }

        [Display(Name = "Cimema Logo")]
        public string Logo { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
