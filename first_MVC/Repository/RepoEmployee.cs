using first_MVC.Data;
using first_MVC.Models;
using first_MVC.Repository.Base;

namespace first_MVC.Repository
{
    public class RepoEmployee : MainRepository<Employee>, IRepoEmployee
    {
        private readonly ApplicationDbContext _context;
        public RepoEmployee(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Employee Login(string username, string password)
        {
            Employee emp = _context.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
            return emp;
        }
    }
}
