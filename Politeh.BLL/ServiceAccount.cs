using Politeh.DAL.Model;
using Politeh.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Politeh.BLL.Model;

namespace Politeh.BLL
{
    public class ServiceAccount: Service<Account>
    {
        public ServiceAccount(string path) : base(path)
        {
        }

        public List<AccountDTO> GetAllAccountClient(int ClientId)
        {
            result = repo.GetAll();

            result.ListData = result.ListData
                .Where(w => w.ClientId == ClientId)
                .ToList();

            return _iMapper.Map<List<AccountDTO>>(result.Data);
        }
    }
}
