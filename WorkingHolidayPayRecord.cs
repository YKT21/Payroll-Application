using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPayProject
{
    class WorkingHolidayPayRecord : PayRecord
    {
        public int Visa { get; private set; }
        public int YearToDate { get; private set; }

        public override double Tax
        {
            get
            {
                return TaxCalculator.calculateWorkingHolidayTax(Gross, YearToDate);
            }
        }

        //constructor
        /// <summary>
        /// constructor for Working Holiday Pay Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hour"></param>
        /// <param name="rate"></param>
        /// <param name="Visa"></param>
        /// <param name="YearToDate"></param>
        public WorkingHolidayPayRecord(int id, double[] hour, double[] rate, int Visa, int YearToDate) : base(id, hour, rate)
        {
            this.Visa = Visa;
            this.YearToDate = YearToDate;
        }

        //method
        /// <summary>
        /// Get Details and Return details for Working Holiday Visa Employee 
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            return base.GetDetails() + $"\nVISA:\t {Visa}\nYTD:\t{Gross+YearToDate:c}";
        }         

    }

}
