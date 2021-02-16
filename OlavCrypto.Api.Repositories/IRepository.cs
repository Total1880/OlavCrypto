using System.Collections.Generic;

namespace OlavCrypto.Api.Repositories
{
    interface IRepository<T>
    {
        bool Create(T item);
        IList<T> Get();
        bool Update(T item);
        bool Delete(int id);
    }
}
