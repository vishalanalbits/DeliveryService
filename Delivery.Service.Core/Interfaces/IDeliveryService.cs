using Delivery.Service.Common.dto.Request;
using Delivery.Service.Common.dto.Response;

namespace Delivery.Service.Core.Interfaces
{
    public interface IDeliveryService
    {
        public Task<List<DeliveryResponseDto>> GetDeliverys();
        public Task<DeliveryResponseDto> GetDelivery(long id);
        public Task<DeliveryResponseDto> RegisterDelivery(RegisterDelivaryRequestDto requestDto);
        public Task<DeliveryResponseDto> UpdateDelivery(long id, UpdateDeliveryRequestDto requestDto);
        public Task<DeleteEntityResponseDto> DeleteDelivery(long id);
    }
}
