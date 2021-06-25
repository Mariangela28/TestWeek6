using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Week6.Repository
{
    public interface IRepositoryCarPolicy<T>
    {
        public T Create(T item);

        public ICollection<T> GetAll();
    }
}
