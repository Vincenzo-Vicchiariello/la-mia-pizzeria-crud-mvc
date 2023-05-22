using LaMiaPizzeriaNuova.Models.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeriaNuova.Models

{

    public class PizzaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(40, ErrorMessage = "Il nome non può avere più di 40 caratteri")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage = "L'URL inserito non è un url valido!")]
        [MaxLength(300)]
        public string ImgSource { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [MoreThanZero(ErrorMessage = "Il prezzo deve essere maggiore di 0!")]
        public float Price { get; set; }


        public PizzaModel()
        {
        }


        public PizzaModel(string name, string description, string imgSource, float price)
        {
            Name = name;
            Description = description;
            ImgSource = imgSource;
            Price = price;
        }
    }
}
