using Politeh.DAL.Model;
using Politeh.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Politeh.BLL.Model;
using AutoMapper;

namespace Politeh.BLL
{
    public abstract class Service<T> where T:class
    {
        protected IRepository<T> repo = null;
        protected ReturnResult<T> result = null;
        protected readonly IMapper _iMapper;

        public Service(string path)
        {
            repo = new Repository<T>(path);
            _iMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                cfg.CreateMap<Account, AccountDTO>().ReverseMap();
                cfg.CreateMap<Address, AddressDTO>().ReverseMap();
            }).CreateMapper();
        }




    }
}
