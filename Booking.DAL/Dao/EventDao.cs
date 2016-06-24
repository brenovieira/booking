using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IEventDao : IDao<Event>
    {
    }

    public class EventDao : AbstractDao<Event>, IEventDao
    {
        public EventDao(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
