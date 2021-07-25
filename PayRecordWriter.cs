using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;

namespace KTPayProject
{
     public class PayRecordWriter
     {
        //Write to CSV file 
        public  static void Write(string file, List<PayRecord> records, bool writetoconsole=false)
        {
            StreamWriter stream = new StreamWriter(Path.GetFullPath($@"..\..\..\Export\{file}.csv"));
            try
            {
                var csv = new CsvWriter(stream);
                csv.WriteRecords(records);
                if(writetoconsole == true)
                {
                    foreach (var x in records )
                    {
                        Console.WriteLine(x.GetDetails());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: ${e.Message.ToString()}");
            }
            finally
            {
                stream.Close();
            }
        }

    }
}
