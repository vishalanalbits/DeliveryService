using Delivery.Service.Data.Models;

namespace Delivery.Service.Data.Interfaces
{
    public interface IDeliveryRepository
    {
        public Task<bool> IsEmailTaken(string email);
        public Task<bool> IsUsernameTaken(string username);
        public Task<List<Deliverys>> GetAllDeliverys();
        public Task<Deliverys?> GetDeliveryById(long id);
        public Task<Deliverys> RegisterDelivery(Deliverys Delivery);
        public Task<Deliverys> UpdateDelivery(Deliverys Delivery);
        public Task DeleteDelivery(Deliverys Delivery);
    }
}
