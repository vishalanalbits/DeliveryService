using AutoMapper;
using Delivery.Service.Common.dto.Request;
using Delivery.Service.Common.dto.Response;
using Delivery.Service.Common.Enums;
using Delivery.Service.Core.Interfaces;
using Delivery.Service.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Service.API.Controllers
{
    [ApiController]
    [Route("/api")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        private readonly HttpClient _getwayApiClient;

        public DeliveryController(IDeliveryService deliveryService, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _getwayApiClient = httpClientFactory.CreateClient("GetwayApi");
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        [HttpGet("deliveryPersonal")]
        public async Task<IActionResult> GetDeliverys()
        {
            List<DeliveryResponseDto> responseDto = await _deliveryService.GetDeliverys();

            return Ok(responseDto);
        }

        [HttpGet("deliveryPersonal/{id}")]
        public async Task<IActionResult> GetDelivery(long id)
        {
            DeliveryResponseDto responseDto = await _deliveryService.GetDelivery(id);

            return Ok(responseDto);
        }

        [HttpPost("deliveryPersonal")]
        public async Task<IActionResult> RegisterDelivery([FromBody] RegisterDelivaryRequestDto requestDto)
        {
            DeliveryResponseDto responseDto = await _deliveryService.RegisterDelivery(requestDto);

            return Ok(responseDto);
        }

        [HttpPut("deliveryPersonal/{id}")]
        public async Task<IActionResult> UpdateDelivery(long id, [FromBody] UpdateDeliveryRequestDto requestDto)
        {
            DeliveryResponseDto responseDto = await _deliveryService.UpdateDelivery(id, requestDto);

            return Ok(responseDto);
        }

        [HttpDelete("deliveryPersonal/{id}")]
        public async Task<IActionResult> DeleteDelivery(long id)
        {
            DeleteEntityResponseDto responseDto = await _deliveryService.DeleteDelivery(id);

            return Ok(responseDto);
        }

        [HttpPut("deliveryPersonal/orderStatus/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(long id, DeliveryStatus status)
        {
            var order = await _getwayApiClient.GetFromJsonAsync<OrderDetailResponse>($"/orders/get-order/{id}");
            var updateOrder = _mapper.Map<OrderUpdateRequest>(order);
            updateOrder.status = status.ToString();
            var responseDetails1 = await _getwayApiClient.PutAsJsonAsync<OrderUpdateRequest>($"/orders/update/{id}", updateOrder);

            return Ok(await responseDetails1.Content.ReadAsStringAsync());
        }
    }
}
