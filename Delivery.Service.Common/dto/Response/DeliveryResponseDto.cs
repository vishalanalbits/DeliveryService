namespace Delivery.Service.Common.dto.Response
{
    public class DeliveryResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //public UserType UserType { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; } = false;
        public string Phone { get; set; } = string.Empty;
        public string Vehical { get; set; } = string.Empty;
    }
}
