﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var sales = new SalesCounter("sales.csv");
            //var amountPerStore = sales.GetPerStoreSales();
            var amountPerCategory = sales.GetPerCategorySales();
            foreach (var obj in amountPerCategory)
            {
                Console.WriteLine("{0}{1}", obj.Key, obj.Value);
            }
        }        
    }
}
