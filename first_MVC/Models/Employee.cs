using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace first_MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public double Phone { get; set; }
        [DisplayName("Salary")]
        public double Salary { get; set; }
        public double Commission { get; set; }
    }
}
