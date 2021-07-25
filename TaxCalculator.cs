using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPayProject
{
    class TaxCalculator
    {
        //Calculate TAX for Resident
        public static double calculateResidentTax(double gross)
        {
            if (gross <= 72)
            {
                return (gross * 0.19) - 0.19;
            }
            else if (gross <= 361)
            {
                return (gross * 0.2342) - 3.213;
            }
            else if (gross <= 932)
            {
                return (gross * 0.3477) - 44.2476;
            }
            else if (gross <= 1380)
            {
                return (gross * 0.345) - 41.7311;
            }
            else if (gross <= 3111)
            {
                return (gross * 0.39) - 103.8657;
            }
            else 
            {
                return (gross * 0.47) - 352.7888;
            }                    
        }

        //Calculate TAX for Working Holiday Resident
        internal static double calculateWorkingHolidayTax(double gross, double yearToDate)
        {
            if(gross + yearToDate <= 37000)
            {
                return (gross * 0.15);
            }
            else if (gross + yearToDate <= 90000)
            {
                return (gross * 0.32);
            }
            else if (gross +yearToDate <= 180000)
            {
                return (gross * 0.37);
            }
            else { return (gross * 0.45); }
        }
    }
}
