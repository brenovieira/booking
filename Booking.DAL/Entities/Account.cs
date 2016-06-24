using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Index(IsUnique = true)]
        public string Username { get; set; }

        public string Password { get; set; }

        [Index(IsUnique = true)]
        public string Email { get; set; }
    }
}
