using Delivery.Service.Common.dto.Request;

namespace Delivery.Service.Common.dto.Response
{
    public class OrderDetailResponse : OrderUpdateRequest
    {
        public long orderId { get; set; }        
    }
}
