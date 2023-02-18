using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlay = true;
            while (isPlay == true)
            {
                var randomNum = generateRandomNumber();
                List<string> inputNum = new List<string>();
                Console.WriteLine(string.Join("", randomNum));

                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～\n------\n");

                int A = 0;
                int B = 0;
                while (A != 4)
                {
                    A = 0;
                    B = 0;
                    inputNum = new List<string>();
                    Console.Write("請輸入 4 個數字：");
                    string input = Console.ReadLine();

                    foreach (char num in input)
                    {
                        inputNum.Add(num.ToString());
                    }

                    foreach (string inter in randomNum.Intersect(inputNum))
                    {
                        if (randomNum.IndexOf(inter) == inputNum.IndexOf(inter)) 
                        {
                            A += 1;
                        }
                        else
                        {
                            B += 1;
                        }
                    }

                    Console.WriteLine($"{A}A{B}B");
                }
                Console.Write("恭喜你！猜對了！！\r\n------\r\n你要繼續玩嗎？(y/n): ");
                if (Console.ReadLine() == "n")
                {
                    Console.WriteLine("遊戲結束，下次再來玩喔～");
                    isPlay = false;
                }
                Console.WriteLine();
            }
        }

        private static List<string> generateRandomNumber()
        {
            List<string> list = new List<string>();
            while (list.Count < 4)
            {
                Random random = new Random();
                int number = random.Next(1, 10);
                if (list.Contains(number.ToString()) == false || list.Count == 0)
                {
                    list.Add(number.ToString());
                }
            }
            return (list);
        }
    }
}
