using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Service.Common.dto.Request
{
    public class OrderUpdateRequest
    {
        public long restaurantId { get; set; }
        public long customerId { get; set; }
        public long deliveryId { get; set; }
        public string status { get; set; } = string.Empty;
        public string item_name { get; set; } = string.Empty;
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public string orderDate { get; set; }
    }
}
