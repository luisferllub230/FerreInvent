using Source.Core.Domain.Common;

namespace Source.Core.Domain.Entities
{
    public class Sales : AuditableBaseEntity
    {

        public DateTime dateSales { get; set; }
        public int quantity { get; set; }
        public float totalCosto { get; set; } 
        
        //CUSTUMER
        public int custumerID { get; set; }
        public Custumers custumer { get; set; }

        //INVENTORY
        public int inventoryID { get; set; }
        public Inventory inventory { get; set; }

        public ICollection<Sales> sales { get; set; }
    }
}
