using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politeh.DAL
{
    public class RepositorySQL : IRepository<T>
    {
        public ReturnResult<T> Create(T data)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
