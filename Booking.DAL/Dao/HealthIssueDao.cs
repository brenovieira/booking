using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IHealthIssueDao : IDao<HealthIssue>
    {
    }

    public class HealthIssueDao : AbstractDao<HealthIssue>, IHealthIssueDao
    {
        public HealthIssueDao(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
