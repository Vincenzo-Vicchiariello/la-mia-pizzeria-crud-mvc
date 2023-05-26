namespace LaMiaPizzeriaNuova.Models
{


    public class PizzaCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PizzaModel> Pizze { get; set; }

        public PizzaCategory(string name)
        {
            Name = name;
            Pizze = new List<PizzaModel>();
        }

    }
}
