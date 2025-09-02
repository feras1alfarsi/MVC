using first_MVC.Models;

namespace first_MVC.Repository.Base
{
    public interface IRepoEmployee : IRepository<Employee>
    {
        Employee Login (string username, string password);
    }
}
