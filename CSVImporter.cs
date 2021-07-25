using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KTPayProject
{
     public class CSVImporter
     {
        public static List<PayRecord> ImportPayRecords(string file)
        {
            var records = new List<PayRecord>();
            //Read the csv file
            StreamReader stream = new StreamReader(Path.GetFullPath($@"..\..\..\Import\{file}.csv")); 
            try
            {
                stream.ReadLine();
                int id = -1;
                string visa = string.Empty;
                string yearToDate = string.Empty;
                List<double> hours = new List<double>();
                List<double> rates = new List<double>();
                while (stream.EndOfStream == false)
                {
                    string[] columns = stream.ReadLine().Split(',');
                    if (int.Parse(columns[0])!= id && id != -1)
                    {
                        records.Add(createPayRecords(id, hours.ToArray(), rates.ToArray(), visa, yearToDate));
                        hours.Clear();
                        rates.Clear();
                    }
                    id = int.Parse(columns[0]);
                    hours.Add(double.Parse(columns[1]));
                    rates.Add(double.Parse(columns[2]));
                    visa = columns[3];
                    yearToDate = columns[4];                    
                }
                if (id != -1)
                {
                    records.Add(createPayRecords(id, hours.ToArray(), rates.ToArray(), visa, yearToDate));
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine($"Error: {e.Message.ToString()}");
            }
            finally
            {
                stream.Close();
            }
            return records;
        }
     
        //Create Pay Records for Resident and Working Holiday Employees
        private static PayRecord createPayRecords(int id, double[] hours, double[] rates, string visa, string yearToDate)
        {
            if (string.IsNullOrEmpty(visa))
            {
                return new ResidentPayRecord(id, hours.ToArray(), rates.ToArray());
            }
            else
            {
                return new WorkingHolidayPayRecord(id, hours.ToArray(), rates.ToArray(), int.Parse(visa), int.Parse(yearToDate));
            }
        }
    }
}

