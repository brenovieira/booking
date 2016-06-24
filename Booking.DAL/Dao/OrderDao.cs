using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IOrderDao : IDao<Order>
    {
    }

    public class OrderDao : AbstractDao<Order>, IOrderDao
    {
        public OrderDao(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
