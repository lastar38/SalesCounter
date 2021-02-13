using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter
{

    public class SalesCounter
    {
        private IEnumerable<Sale> _sales;

        public SalesCounter(string filePath)
        {
            _sales = ReadSales(filePath);
        }

        private static IEnumerable<Sale> ReadSales(string filePath)
        {
            List<Sale> sales = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                Sale sale = new Sale
                {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            return sales;
        }

        public IDictionary<string, int> GetPerStoreSales()
        {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales)
            {
                if (dict.ContainsKey(sale.ShopName))
                {
                    dict[sale.ShopName] += sale.Amount;
                }
                else
                {
                    dict[sale.ShopName] = sale.Amount;
                }
            }
            return dict;
        }

        public IDictionary<string, int> GetPerCategorySales()
        {
            var dict = new SortedDictionary<string, int>();
            foreach (var sales in _sales)
            {
                if (dict.ContainsKey(sales.ProductCategory))
                {
                    dict[sales.ProductCategory] += sales.Amount;
                }
                else
                {
                    dict[sales.ProductCategory] = sales.Amount;
                }
            }
            return dict;
        }
    }
}
