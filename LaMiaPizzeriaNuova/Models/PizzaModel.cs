using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeriaNuova.Models

{
    public class PizzaModel
    {
        int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [MaxLength(300)]
        public string imgSource { get; set; }
        public float Price { get; set;}
    }
}
