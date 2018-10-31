using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Class which presents method to serve accounts
    /// </summary>
    public class BankAccountService : IAccountService
    {
        #region fields
        private List<Client> clientsList;
        #endregion

        #region properties
        /// <summary>
        /// Returns clients list
        /// </summary>
        public List<Client> ClientsList
        {
            get { return clientsList; }
            set { clientsList = value; }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Method closes chosen account, but save bonus points
        /// </summary>
        /// /// <exception cref="ArgumentNullException">Thrown when passport have null value</exception>
        /// <param name="passportNumber">passport number</param>
        /// <param name="idAccount">number account</param>
        public void CloseAccount(string passportNumber, int idAccount)
        {
            if (passportNumber == null)
            {
                throw new ArgumentNullException($"{nameof(passportNumber)} has no value");
            }

            int indexClient = (int)FindIndexClientByPasport(ClientsList, passportNumber);
            int indexAccount = (int)FindIndexAccountById(ClientsList[indexClient].Accounts, idAccount);
            WithdrawMoney(idAccount, clientsList[indexClient].Accounts[indexAccount].AccountValue);
            clientsList[indexClient].Accounts[indexAccount].IsOpened = false;
        }

        /// <summary>
        /// Create new account 
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when passport have null value</exception>
        /// <param name="passportNumber">passport number</param>
        /// <param name="bonus">type of the card depend on which calculates bonus points</param>
        public void CreateAccount(string passportNumber, IBonus bonus)
        {
            if (passportNumber == null)
            {
                throw new ArgumentNullException($"{nameof(passportNumber)} has no value");
            }

            int indexClient = (int)FindIndexClientByPasport(ClientsList, passportNumber);
            Account newAccount = new Account { AccountBehaviour = bonus };
            clientsList[indexClient].AddAccount(newAccount);
            clientsList[indexClient].Accounts[clientsList[indexClient].Accounts.Count].IsOpened = true;
        }

        /// <summary>
        /// Deposits money
        /// </summary>
        /// <param name="idAccount">account number</param>
        /// <param name="money">amount of money</param>
        public void PutMoney(int idAccount, decimal money)
        {
            foreach (var client in ClientsList)
            {
                foreach (var account in client.Accounts)
                {
                    if (account.IdNumber == idAccount)
                    {
                        account.AccountValue += money;
                        account.BonusPoints += account.IncreaceBonusPut();
                    }
                }
            }
        }

        /// <summary>
        /// Withdraws money
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when enough money to withdraw</exception>
        /// <param name="idAccount">number of account</param>
        /// <param name="money">amount of money to withdraw</param>
        public void WithdrawMoney(int idAccount, decimal money)
        {
            foreach (var client in ClientsList)
            {
                foreach (var account in client.Accounts)
                {
                    if (account.IdNumber == idAccount)
                    {
                        if (account.AccountValue < money)
                        {
                            throw new ArgumentException("Not enough money to withdraw");
                        }

                        account.AccountValue -= money;
                        if (account.ReduceBonusGet() > account.BonusPoints)
                        {
                            account.BonusPoints = 0;
                        }
                        else
                        {
                            account.BonusPoints -= account.ReduceBonusGet();
                        }
                    }
                }
            }
        }

        #endregion

        #region private methods
        private int? FindIndexClientByPasport(List<Client> clientsList, string pasportNumber)
        {
            int? index = null;
            for (int i = 0; i < clientsList.Count; i++)
            {
                if (clientsList[i].PassportNumber.Equals(pasportNumber))
                {
                    return index = i;
                }
            }

            return null;
        }

        private int? FindIndexAccountById(List<Account> accountsList, int id)
        {
            int? index = null;
            for (int i = 0; i < accountsList.Count; i++)
            {
                if (accountsList[i].IdNumber == id)
                {
                    return index = i;
                }
            }

            return null;
        }
        #endregion
    }
}
