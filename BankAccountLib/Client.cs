using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Describes client entity
    /// </summary>
    public class Client
    {
        #region fields
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string passportNumber;
        private List<Account> accounts;
        #endregion

        #region properties
        /// <summary>
        /// Returns and sets passport number
        /// </summary>
        public string PassportNumber
        {
            get { return passportNumber; }
            set { passportNumber = value; }
        }

        /// <summary>
        /// Returns and sets first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Returns and sets last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Returns and sets e-mail
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Returns and sets phone number
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        /// <summary>
        /// Returns and sets accounts list
        /// </summary>
        public List<Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Add account to the accounts list
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when account not chosen</exception>
        /// <param name="newAccount">new account</param>
        public void AddAccount(Account newAccount)
        {
            if (newAccount == null)
            {
                throw new ArgumentNullException($"{nameof(newAccount)} must have value");
            }

            accounts.Add(newAccount);
        }

        /// <summary>
        /// Deletes account by identification number
        /// </summary>
        /// <param name="idAccountToDelete">identification number</param>
        public void DeleteAccount(int idAccountToDelete)
        {
            int index = 0;
            foreach (var item in accounts)
            {
                if (item.IdNumber == idAccountToDelete)
                {
                    accounts.RemoveAt(index);
                    break;
                }

                ++index;
            }
        }

        /// <summary>
        /// Deletes account by Account type
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when account to delete have no value</exception>
        /// <param name="accountToDelete"></param>
        public void DeleteAccount(Account accountToDelete)
        {
            if (accountToDelete == null)
            {
                throw new ArgumentNullException(nameof(accountToDelete));
            }

            accounts.Remove(accountToDelete);
        }
        #endregion

        #region override methods
        /// <summary>
        /// String representation of current client
        /// </summary>
        /// <returns>string representation of the client</returns>
        public override string ToString()
        {
            StringBuilder accountsInfo = new StringBuilder();
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            foreach (var item in accounts)
            {
                accountsInfo.AppendFormat("Id account: {0}, money left {1:C2}, bonus points {2}\n", item.IdNumber, item.AccountValue, item.BonusPoints);
            }

            return string.Format("Client: {0} {1}, email: {2}, phone number: {3}, Accounts information: \n{4}", FirstName, LastName, Email, PhoneNumber, accountsInfo);
        }
        #endregion
    }
}
