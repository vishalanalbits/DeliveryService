namespace Delivery.Service.Data.Models
{
    public class Deliverys
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? ImagePublicId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; } = false;
        public string Phone { get; set; } = string.Empty;
        public string Vehical { get; set; } = string.Empty;
    }
}
