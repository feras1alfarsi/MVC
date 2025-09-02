﻿namespace first_MVC.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
