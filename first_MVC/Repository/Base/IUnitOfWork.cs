using first_MVC.Models;

namespace first_MVC.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoProduct Products { get; }

        IRepoEmployee Employees { get; }
        IRepository<Category> Categories { get; }

        //IRepository<Employee> Employees { get; }

        void Save();
    }
}
