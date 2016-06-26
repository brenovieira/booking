using System.Linq;
using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IOrderDao : IDao<Order>
    {
        IQueryable<Order> GetByConfirmation(string confirmation);
    }

    public class OrderDao : AbstractDao<Order>, IOrderDao
    {
        public OrderDao(DBContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Order> GetByConfirmation(string confirmation)
        {
            return Queryable().Where(s => s.Confirmation == confirmation);
        }
    }
}
