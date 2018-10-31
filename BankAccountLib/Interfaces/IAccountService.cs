using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    public interface IAccountService
    {
        void WithdrawMoney(int idAccount, decimal money);

        void PutMoney(int idAccount, decimal money);

        void CloseAccount(string pasportNumber, int idAccount);

        void CreateAccount(string pasportNumber, IBonus type);
    }
}
