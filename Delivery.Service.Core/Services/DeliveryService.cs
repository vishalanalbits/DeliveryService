using AutoMapper;
using Delivery.Service.Common.dto.Request;
using Delivery.Service.Common.dto.Response;
using Delivery.Service.Common.Exceptions;
using Delivery.Service.Core.Interfaces;
using Delivery.Service.Data.Interfaces;
using Delivery.Service.Data.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Delivery.Service.Core.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IValidator<Deliverys> _validator;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository, IValidator<Deliverys> validator, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<DeliveryResponseDto> GetDelivery(long id)
        {
            Deliverys? delivery = await _deliveryRepository.GetDeliveryById(id);

            if (delivery == null)
            {
                throw new ResourceNotFoundException("Delivery with this id doesn't exist");
            }

            return _mapper.Map<DeliveryResponseDto>(delivery);
        }

        public async Task<List<DeliveryResponseDto>> GetDeliverys()
        {
            List<Deliverys> deliverys = await _deliveryRepository.GetAllDeliverys();

            return _mapper.Map<List<DeliveryResponseDto>>(deliverys);
        }

        public async Task<DeliveryResponseDto> RegisterDelivery(RegisterDelivaryRequestDto requestDto)
        {
            Deliverys delivery = _mapper.Map<Deliverys>(requestDto);

            ValidationResult validationResult = _validator.Validate(delivery);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (await _deliveryRepository.IsEmailTaken(delivery.Email))
            {
                throw new UserAlreadyExistsException("Delivery with this email already exists");
            }

            if (await _deliveryRepository.IsUsernameTaken(delivery.Username))
            {
                throw new UserAlreadyExistsException("Delivery with this username already exists");
            }

            // Hash password
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            delivery.Password = BCrypt.Net.BCrypt.HashPassword(delivery.Password, salt);

            delivery = await _deliveryRepository.RegisterDelivery(delivery);

            DeliveryResponseDto responseDto = _mapper.Map<DeliveryResponseDto>(delivery);

            return responseDto;
        }

        public async Task<DeliveryResponseDto> UpdateDelivery(long id, UpdateDeliveryRequestDto requestDto)
        {
            Deliverys? delivery = await _deliveryRepository.GetDeliveryById(id);

            if (delivery == null)
            {
                throw new ResourceNotFoundException("Delivery with this id doesn't exist");
            }

            Deliverys updatedDelivery = _mapper.Map<Deliverys>(requestDto);

            ValidationResult validationResult = _validator.Validate(updatedDelivery, options =>
            {
                options.IncludeProperties(x => x.Username);
                options.IncludeProperties(x => x.Email);
                options.IncludeProperties(x => x.FirstName);
                options.IncludeProperties(x => x.LastName);
            });

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (await _deliveryRepository.IsEmailTaken(updatedDelivery.Email) && updatedDelivery.Email != delivery.Email)
            {
                throw new UserAlreadyExistsException("Delivery with this email already exists");
            }

            if (await _deliveryRepository.IsUsernameTaken(updatedDelivery.Username) && updatedDelivery.Username != delivery.Username)
            {
                throw new UserAlreadyExistsException("Delivery with this username already exists");
            }

            _mapper.Map(requestDto, delivery);

            delivery = await _deliveryRepository.UpdateDelivery(delivery);

            DeliveryResponseDto responseDto = _mapper.Map<DeliveryResponseDto>(delivery);
            //responseDto.UserType = UserType.Delivery;

            return responseDto;
        }

        public async Task<DeleteEntityResponseDto> DeleteDelivery(long id)
        {
            Deliverys? delivery = await _deliveryRepository.GetDeliveryById(id);

            if (delivery == null)
            {
                throw new ResourceNotFoundException("Delivery with this id doesn't exist");
            }

            await _deliveryRepository.DeleteDelivery(delivery);

            return _mapper.Map<DeleteEntityResponseDto>(delivery);
        }
    }
}
