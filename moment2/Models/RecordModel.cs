using System.ComponentModel.DataAnnotations;

namespace moment2.Models
{
    public class RecordModel
    {
        //properties

        [Display(Name = "Utgiven år:")]
        [Required(ErrorMessage = "Produktionsår måste vara tillagt")]
        [MaxLength(4)]
        public string? ProdYear { get; set; }

        [Display(Name = "Artist:")]
        [Required(ErrorMessage = "Artist måste vara tillagt")]
        [MaxLength(40)]
        public string? Artist { get; set; }

        [Display(Name = "Skivans namn:")]
        [Required(ErrorMessage = "Skivans titel måste vara tillagd")]
        public string? Title { get; set; }

        [Display(Name = "Antalet spår på skiva:")]
        public int? Tracks { get; set; }

        [Display(Name = "Vill du berätta något om skivan?")]
        [MaxLength(200)]
        public string? Opinion { get; set; }

        [Display(Name = "Genre:")]
        [Required(ErrorMessage = "Genre måste avra tillagd")]
        public string? Genre { get; set; }


    }
}
