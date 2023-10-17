using Politeh.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politeh.BLL.Model
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public int ClientId { get; set; }
        public bool IsActive { get; set; }
        public double Balance { get; set; }
        public Currency Currency { get; set; }

        private string _number;
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                if(!value.StartsWith("KZ"))
                    _number = "KZ"+ value;
                else
                    _number = value;
            }
        }

        public DateTime ExpiryDate { get; set; }
        public int TypeAccount { get; set; }

        public static AccountDTO operator +(AccountDTO acc1, AccountDTO acc2)
        {
            if (acc1.Currency != acc2.Currency)
                throw new InvalidOperationException("Нельзя сумировать деньги разных валют");

            return new AccountDTO { Balance = acc1.Balance + acc2.Balance };
        }
        public static bool operator true(AccountDTO acc1)
        {
            return acc1.Balance !=0;
        }

        public static bool operator false(AccountDTO acc1)
        {
            return acc1.Balance <=0;
        }
    }
}
