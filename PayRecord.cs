using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPayProject
{
    public abstract class PayRecord
    {
        //properties
        /// <summary>
        /// Hours and Rates
        /// </summary>
        protected double[] _hours;
        protected double[] _rates;

        //properties
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }

        //Gross
        /// <summary>
        /// Gross
        /// </summary>
        public double Gross 
        { get
            {
                double Gross = 0;
                for (int i = 0; i < _hours.Length; i++)
                {
                    Gross += _hours[i] * _rates[i];
                }
                return Gross;
            }
        }

        /// <summary>
        /// TAX
        /// </summary>
        public abstract double Tax { get; }

        /// <summary>
        /// Net
        /// </summary>
        public double Net
        { get
            {
                return Gross - Tax;
            }
        }
                       
        //contructors
        /// <summary>
        /// Constructor for PayRecord 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        public PayRecord(int id, double [] hours, double[] rates)
        {
            this.id = id;
            this._hours = hours;
            this._rates = rates;
        }

        //method
        /// <summary>
        /// Get Details and Return Employee Gross, Net, TAX
        /// </summary>
        /// <returns></returns>
        public virtual string GetDetails()
        {
            return $"------------EMPLOYEE: {id}---------------\nGROSS:\t{Gross:c}\nNET:\t{Net:c}\nTAX:\t{Tax:c}";
        }       
    }
}


