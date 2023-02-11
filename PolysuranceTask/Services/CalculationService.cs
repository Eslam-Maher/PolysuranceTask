using PolysuranceTask.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PolysuranceTask.Services
{
    public class CalculationService
    {
        private List<Order> orders;
        private List<Product> products;
        private List<Discount> discounts;
        private Dictionary<int, float> salesPerOrder;
        public CalculationService() {
            orders = Helper.getOrdersFromJson();
            products = Helper.getProductsFromJson();
            discounts = Helper.getDiscountsFromJson();
            salesPerOrder = new Dictionary<int, float>();
            calcSalesPerOrder();
        }

        private void calcSalesPerOrder() {
            orders.ForEach(o =>
            {
                float totalSales = 0;
                o.items.ForEach(i =>
                {
                    totalSales += i.quantity * products.FirstOrDefault(x => x.sku == i.sku).price;
                });
                salesPerOrder.Add(o.orderId, totalSales);
            });
        }
        public float getTotalSalesBeforeDiscounts() {

            return salesPerOrder.Values.Sum();

        }
        public float getTotalSalesAfterDiscounts() {


            return getTotalSalesBeforeDiscounts() - getTotalDiscountsMoney();
        }
        public float getTotalDiscountsMoney() {

            float totalDiscount= 0;
            foreach (KeyValuePair<int,float> item in salesPerOrder)
            {
                string orderDiscountId = orders.FirstOrDefault(o => o.orderId == item.Key).discount;
                totalDiscount += (item.Value * discounts.FirstOrDefault(d => d.key == orderDiscountId).value);
            }
            return totalDiscount;
        }
        public float getAverageDiscountsPerCustomer() {
        
        
            return orders.Where(o=> !string.IsNullOrEmpty(o.discount)).Count()/orders.Count;
        
        }

    }
}
