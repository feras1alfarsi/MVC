using System.ComponentModel.DataAnnotations;

namespace first_MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }
        public double Phone { get; set; }
        public double Salary { get; set; }
        public double Commission { get; set; }
    }
}
