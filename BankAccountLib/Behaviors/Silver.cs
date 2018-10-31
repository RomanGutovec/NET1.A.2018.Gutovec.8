using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Class which describes behavior Platinum accounts to increase and reduce bonus points
    /// </summary>
    public class Silver : IBonus
    {
        #region fields
        private int costPutOperation;
        private int costGetCurrentValue;
        #endregion

        #region constructor
        /// <summary>
        /// Create instance with necessary costs
        /// </summary>
        /// <param name="costPut">quantity bonus point with add operation</param>
        /// <param name="costGet">quantity bonus point with withdraw operation</param>
        public Silver(int costPut = 20, int costGet = 15)
        {
            CostPutOperation = costPut;
            CostGetCurrentValue = costGet;
        }
        #endregion

        #region properties
        /// <summary>
        /// Returns current cost withdraw operation in points
        /// <exceptions cref="ArgumentException">Thrown when set value less than 0</exceptions>
        /// </summary>
        public int CostGetCurrentValue
        {
            get
            {
                return costGetCurrentValue;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Points must be positive");
                }

                costGetCurrentValue = value;
            }
        }

        /// <summary>
        /// Returns current cost put operation in points
        /// <exceptions cref="ArgumentException">Thrown when set value less than 0</exceptions>
        /// </summary>
        public int CostPutOperation
        {
            get
            {
                return costPutOperation;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Points must be positive");
                }

                costPutOperation = value;
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Returns current cost withdraw operation in points
        /// </summary>
        /// <returns>cost of put operation</returns>
        public int ReduceBonusGet()
            => CostGetCurrentValue;

        /// <summary>
        /// Returns current cost put operation in points
        /// </summary>
        /// <returns>cost of put operation</returns>
        public int IncreaceBonusPut()
            => CostPutOperation;
        #endregion
    }
}
