using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IAvailabilityDao : IDao<Availability>
    {
    }

    public class AvailabilityDao : AbstractDao<Availability>, IAvailabilityDao
    {
        public AvailabilityDao(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
