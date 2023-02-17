using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHW
{
    internal class Product
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
    internal class csvHeaders
    {
        public string 商品編號
        { get; set; }
        public string 商品名稱
        { get; set; }
        public int 商品數量
        { get; set; }
        public int 價格
        { get; set; }
        public string 商品類別
        { get; set; }
    }
}
