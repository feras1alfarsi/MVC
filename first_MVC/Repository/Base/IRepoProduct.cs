using first_MVC.Models;

namespace first_MVC.Repository.Base
{
    public interface  IRepoProduct : IRepository<Product>
    {
        IEnumerable<Product> FindAllproducts();
        
    }
}
