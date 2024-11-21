using AutoMapper;
using Delivery.Service.Common.dto.Request;
using Delivery.Service.Common.dto.Response;
using Delivery.Service.Data.Models;

namespace Delivery.Service.Core.Mapping
{
    public class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<RegisterDelivaryRequestDto, Deliverys>();

            CreateMap<Deliverys, DeliveryResponseDto>();

            CreateMap<UpdateDeliveryRequestDto, Deliverys>();

            CreateMap<Deliverys, DeleteEntityResponseDto>();

            CreateMap<OrderDetailResponse, OrderUpdateRequest>();
        }
    }
}
