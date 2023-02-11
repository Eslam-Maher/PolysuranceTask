using PolysuranceTask.Models;
using PolysuranceTask.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolysuranceTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculationService cs = new CalculationService();
            Console.WriteLine($"Total sales before discount {cs.getTotalSalesBeforeDiscounts()}" );
            Console.WriteLine($"Total sales after discount {cs.getTotalSalesAfterDiscounts()}");
            Console.WriteLine($"Total amount of money lost via Discount Codes{cs.getTotalDiscountsMoney()}");
            Console.WriteLine($"average amount of discount per customer for the day {cs.getAverageDiscountsPerCustomer()}");

        }
    }
}
