using Microsoft.EntityFrameworkCore;

namespace PocketMonsters.DataAccess.Entities
{
    [PrimaryKey("Id")]
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}