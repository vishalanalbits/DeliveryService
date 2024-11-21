using Delivery.Service.Data.Contexts;
using Delivery.Service.Data.Interfaces;
using Delivery.Service.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Service.Data.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DeliveryDbContext _dbContext;

        public DeliveryRepository(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Deliverys>> GetAllDeliverys()
        {
            return await _dbContext.Deliverys.ToListAsync();
        }

        public async Task<Deliverys?> GetDeliveryById(long id)
        {
            return await _dbContext.Deliverys.FindAsync(id);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _dbContext.Deliverys.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _dbContext.Deliverys.AnyAsync(x => x.Username == username);
        }

        public async Task<Deliverys> RegisterDelivery(Deliverys Delivery)
        {
            await _dbContext.Deliverys.AddAsync(Delivery);
            await _dbContext.SaveChangesAsync();
            return Delivery;
        }

        public async Task<Deliverys> UpdateDelivery(Deliverys Delivery)
        {
            _dbContext.Entry(Delivery).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Delivery;
        }

        public async Task DeleteDelivery(Deliverys Delivery)
        {
            _dbContext.Deliverys.Remove(Delivery);
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
