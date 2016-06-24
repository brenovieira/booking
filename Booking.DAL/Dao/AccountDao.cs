using Booking.DAL.Entities;

namespace Booking.DAL.Dao
{
    public interface IAccountDao : IDao<Account>
    {
    }

    public class AccountDao : AbstractDao<Account>, IAccountDao
    {
        public AccountDao(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
