using Newtonsoft.Json;
using PolysuranceTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolysuranceTask.Services
{
    public static class Helper
    {

        public static List<Order> getOrdersFromJson()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            object orderData = File.ReadAllText(projectDirectory + "/InputJsons/orders.json");
            return JsonConvert.DeserializeObject<List<Order>>(orderData.ToString());
        }
        public static List<Discount> getDiscountsFromJson()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            object orderData = File.ReadAllText(projectDirectory + "/InputJsons/discounts.json");
            return JsonConvert.DeserializeObject<List<Discount>>(orderData.ToString());
        }
        public static List<Product> getProductsFromJson()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            object orderData = File.ReadAllText(projectDirectory + "/InputJsons/products.json");
            return JsonConvert.DeserializeObject<List<Product>>(orderData.ToString());
        }
    }
}
