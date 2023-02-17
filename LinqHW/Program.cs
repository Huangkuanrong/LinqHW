using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Expressions;

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
                var records = csv.GetRecords<csvHeaders>();
                foreach (var record in records)
                {
                    tempList.Add(
                        new Product
                        {
                            SerialNumber = record.商品編號,
                            Name = record.商品名稱,
                            Quantity = record.商品數量,
                            Price = record.價格,
                            Category = record.商品類別
                        }
                    );
                }
            }
            return tempList;
        }
    }
}
