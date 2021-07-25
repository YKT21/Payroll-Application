using System;
using System.Collections.Generic;

namespace KTPayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PayRecord> records = CSVImporter.ImportPayRecords("employee-payroll-data");
            string file = $"{DateTime.Now.Ticks}-records";
            PayRecordWriter.Write(file, records, true);
        }
    }
}
