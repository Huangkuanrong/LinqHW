using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace LinqHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateListFromCSV("product.csv");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static List<Product> CreateListFromCSV(string csvFilePath)
        {
            var tempList = new List<Product>();
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Product>();
                tempList.AddRange(records);
            }
            return tempList;
        }
    }
}
