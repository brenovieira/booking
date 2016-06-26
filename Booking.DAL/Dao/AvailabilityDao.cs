using System.Linq;
using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IAvailabilityDao : IDao<Availability>
    {
        IQueryable<Availability> GetByEventId(int eventId, int quantity);
    }

    public class AvailabilityDao : AbstractDao<Availability>, IAvailabilityDao
    {
        public AvailabilityDao(DBContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Availability> GetByEventId(int eventId, int quantity)
        {
            return Queryable().Where(s => s.EventId == eventId && s.Quantity >= quantity);
        }
    }
}
