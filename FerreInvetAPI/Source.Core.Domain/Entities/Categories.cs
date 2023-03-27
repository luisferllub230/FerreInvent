using Source.Core.Domain.Common;

namespace Source.Core.Domain.Entities
{
    public class Categories : AuditableBaseEntity
    {
        
        public string categoryName { get; set; }

        //Inventory
        public ICollection<Inventory> inventories { get; set; }
    }
}
