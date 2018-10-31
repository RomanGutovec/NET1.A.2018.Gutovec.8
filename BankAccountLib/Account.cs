using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Represents current account 
    /// </summary>
    public class Account : IBonus
    {
        #region fields
        private static int countForId = 0;

        private int idNumber;
        private decimal accountValue;
        private bool isOpened;
        private int bonusPoints;
        private IBonus accountBehaviour;
        #endregion

        #region constructors
        /// <summary>
        /// Creates and initialize account
        /// </summary>
        public Account()
        {
            IdNumber = ++countForId;
            IsOpened = true;
        }
        #endregion 

        #region properties
        /// <summary>
        /// Return identification number of account
        /// </summary>
        public int IdNumber
        {
            get { return idNumber; }
            private set { idNumber = value; }
        }

        /// <summary>
        /// Method which shows open ore close current account
        /// </summary>
        public bool IsOpened
        {
            get { return isOpened; }
            set { isOpened = value; }
        }

        /// <summary>
        /// Returns and sets value of bonus points
        /// </summary>
        public int BonusPoints
        {
            get { return bonusPoints; }
            set { bonusPoints = value; }
        }

        /// <summary>
        /// Returns and sets mechanism to increase and reduce bonus points depend on 
        /// kind account (like Base, Silver, Gold etc.)
        /// </summary>
        public IBonus AccountBehaviour
        {
            get
            {
                return accountBehaviour;
            }

            set
            {
                accountBehaviour = value ?? throw new ArgumentNullException("Type of the card isn't chosen");
            }
        }

        /// <summary>
        /// Returns and sets value to the current account
        /// <exceptions cref="ArgumentException">Thrown when set value less than 0</exceptions>
        /// </summary>
        public decimal AccountValue
        {
            get
            {
                return accountValue;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Sum must be more than 0");
                }

                accountValue = value;
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Method which put money to the current account
        /// </summary>
        /// <param name="money">amount of money to put</param>
        public void Put(decimal money)
        {
            AccountValue += money;
            bonusPoints += IncreaceBonusPut();
        }

        /// <summary>
        /// Method which withdraw money from the current account
        /// </summary>
        /// <param name="money">amount of money to withdraw</param>
        public void Withdraw(decimal money)
        {
            if (AccountValue < money)
            {
                throw new ArgumentException("Not enough money to withdraw");
            }

            AccountValue -= money;
            if (ReduceBonusGet() > BonusPoints)
            {
                BonusPoints = 0;
            }
            else
            {
                bonusPoints -= ReduceBonusGet();
            }
        }

        /// <summary>
        /// Returns amount of bonus point to increase for the put operation
        /// </summary>
        /// <returns></returns>
        public int IncreaceBonusPut()
        {
            return AccountBehaviour.IncreaceBonusPut();
        }

        /// <summary>
        /// Returns amount of bonus point to increase for the withdraw operation
        /// </summary>
        /// <returns></returns>
        public int ReduceBonusGet()
        {
            return AccountBehaviour.ReduceBonusGet();
        }
        #endregion

        #region overrided methods
        /// <summary>
        /// String representation current account with identification number and balance 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Account id: {0} has value {1}$", IdNumber, AccountValue);
        }
        #endregion
    }
}
