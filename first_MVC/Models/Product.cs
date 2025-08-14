using System.ComponentModel.DataAnnotations;

namespace first_MVC.Models
{
    public class Product
    {
        //prop
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
