using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPayProject
{
    class ResidentPayRecord : PayRecord
    {
        public override double Tax
        {
            get
            {
                return TaxCalculator.calculateResidentTax(Gross);
            }
        }

        //constructor
        /// <summary>
        /// Resident Pay Record constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rate"></param>
        public ResidentPayRecord(int id, double [] hours, double [] rate):base (id, hours, rate)
        {
            
        }
    }
}
