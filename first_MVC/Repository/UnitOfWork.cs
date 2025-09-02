using first_MVC.Data;
using first_MVC.Models;
using first_MVC.Repository.Base;

namespace first_MVC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new RepoProduct(_context);
            Categories = new MainRepository<Category>(_context);
            Employees = new RepoEmployee (_context);
        }




        public IRepoProduct Products {get;}

        public IRepository<Category> Categories { get; }

        //public IRepository<Employee> Employees { get; }

        public IRepoEmployee Employees { get; }



        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
