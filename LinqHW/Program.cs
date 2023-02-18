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
            Console.WriteLine("Linq CSV : Input the Question Number and Get the answer \r\n" +
                "Type \"e\" or \"exit\" to stop the program \r\n");
            var list = CreateListFromCSV("product.csv");
            int num = 0;
            while (num == 0)
            {
                Console.Write("Which Question you want to ask (1-17) : ");
                string input = Console.ReadLine();
                string output = "";
                if (input == "exit" || input == "e")
                {
                    break;
                }
                else if (input == "all")
                {
                    for (int i = 1; i <= 16; i += 4){
                        output = Answer(i, list) ;
                        Console.WriteLine($"{i}. {output}");
                        output = Answer(i + 1, list);
                        Console.WriteLine($"{i+1}. {output}");
                        output = Answer(i + 2, list);
                        Console.WriteLine($"{i+2}. {output}");
                        output = Answer(i + 3, list);
                        Console.WriteLine($"{i+3}. {output}");
                        Console.WriteLine("------");
                        Console.ReadKey();
                    }
                }
                else
                {
                    try
                    {
                        num = int.Parse(input);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please input a valid number between 1 - 17.");
                        Console.WriteLine("------");
                    }
                    output = Answer(num, list);
                    Console.WriteLine(output);
                    Console.WriteLine();
                    num = 0;
                }
            }
        }

        static string Answer (int num, List<Product> list)
        {
            string output = "";
            switch (num)
            {
                case 1:
                    output = list.Sum((x) => x.Price).ToString();
                    break;
                case 2:
                    output = list.Average((x) => x.Price).ToString();
                    break;
                case 3:
                    output = list.Sum(x => x.Quantity).ToString();
                    break;
                case 4:
                    output = list.Average(x => x.Quantity).ToString();
                    break;
                case 5:
                    output = list.SingleOrDefault(x => x.Price == list.Max(y => y.Price)).Name;
                    break;
                case 6:
                    output = list.SingleOrDefault(x => x.Price == list.Min(y => y.Price)).Name;
                    break;
                case 7:
                    output = list.Where(x => x.Category == "3C").Sum(x => x.Price).ToString();
                    break;
                case 8:
                    output = (list.Where(x => x.Category == "飲料").Sum(x => x.Price) + list.Where(x => x.Category == "食品").Sum(x => x.Price)).ToString();
                    break;
                case 9:
                    var temp_list = list.Where((x) => x.Category == "食品" && x.Quantity > 100).ToList();
                    foreach (var item in temp_list)
                    {
                        output += item.Name + "\n";
                    }
                    break;
                case 10:
                    var temp_dict = list.Where((x) => x.Price > 1000).ToDictionary((x) => x.Name);
                    foreach (var item in temp_dict)
                    {
                        output += $"{item.Value.Category} - {item.Value.Name}\n";
                    }
                    break;
                case 11:
                    output = list.Where(x => x.Category == list.First((y) => y.Price > 1000).Category)
                        .Average(x => x.Price).ToString();
                    output += "\n";
                    break;
                case 12:
                    temp_list = list.OrderByDescending((x) => x.Price).ToList();
                    foreach (var item in temp_list)
                    {
                        output += $"{item.Name} - {item.Price}\n";
                    }
                    break;
                case 13:
                    temp_list = list.OrderBy((x) => x.Quantity).ToList();
                    foreach (var item in temp_list)
                    {
                        output += $"{item.Name} - {item.Price}\n";
                    }
                    break;
                case 14:
                    foreach (var item in list.Select(x => x.Category).Distinct())
                    {
                        var maxPrice = list.Where(x => x.Category == item).Max(x => x.Price);
                        output += $"{item} - {maxPrice}\n";
                        foreach (var item2 in list.Where(y => y.Category == item && y.Price == maxPrice))
                        {
                            output += $"{item2.Name}\n";
                        }
                        output += "\n";
                    }
                    break;
                case 15:
                    foreach (var item in list.Select(x => x.Category).Distinct())
                    {
                        var maxPrice = list.Where(x => x.Category == item).Max(x => x.Price);
                        output += $"{item} - {maxPrice}\n";
                        foreach (var item2 in list.Where(y => y.Category == item && y.Price == maxPrice))
                        {
                            output += $"{item2.Name}\n";
                        }
                        output += "\n";
                    }
                    break;
                case 16:
                    foreach (var item in list.Where(x => x.Price <= 10000))
                    {
                        output += $"{item.Name} - {item.Price}\n";
                    }
                    break;
            }
            return output;
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
