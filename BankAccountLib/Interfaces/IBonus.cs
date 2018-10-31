using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    public interface IBonus
    {
        int IncreaceBonusPut();

        int ReduceBonusGet();
    }
}
