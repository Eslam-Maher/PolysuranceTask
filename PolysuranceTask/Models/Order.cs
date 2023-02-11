using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolysuranceTask.Models
{
    public class Order
    {
		public int orderId { get; set; }
		public string discount { get; set; }
		public List<ProductQuantity> items { get; set; }
 	
    }
}
