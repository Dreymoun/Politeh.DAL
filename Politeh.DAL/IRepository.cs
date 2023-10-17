using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politeh.DAL
{
    public interface IRepository<T>
    {
        ReturnResult<T> GetAll();
        ReturnResult<T> GetById(int Id);

        ReturnResult<T> Create(T data);

        ReturnResult<T> Delete(int Id);

        ReturnResult<T> Update(T data);

    }
}
