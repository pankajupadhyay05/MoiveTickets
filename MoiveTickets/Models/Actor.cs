using System.ComponentModel.DataAnnotations;

namespace MoiveTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Ful Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture Url is required")]
        public string ProfilePic { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships

        public List<Actor_Movie>? Actors_Movies { get; set; }

    }
}
