
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperDemo
{
    internal class CSVHander
    {
        public static void ImplementationCsvHanding()
        {
            string importFilepath = @"C:\Users\hp\Desktop\data\CSVHelperDemo\CSVHelperDemo\DemoCsvFile.csv";

            string exportFilepath = @"C:\Users\hp\Desktop\data\CSVHelperDemo\CSVHelperDemo\ExportFile.csv";
            //read file
            using (var reader = new StreamReader(importFilepath))
            using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from file csv");
                foreach( AddressData data in records)
                {
                    
                    Console.WriteLine("\t" + data.name);
                   
                    Console.WriteLine("\t" + data.email);
                   
                    Console.WriteLine("\t" + data.city);
                    Console.WriteLine("\t" + data.PhoneNumber);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n----------write to csv file--------------");
                // write csv file
                using var writer = new StreamWriter(exportFilepath);
                using var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture);
                {
                    csvExport.WriteRecords(records);
                }


            }
        }
    }
}
