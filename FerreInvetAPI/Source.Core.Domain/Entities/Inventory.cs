using Source.Core.Domain.Common;

namespace Source.Core.Domain.Entities
{
    public class Inventory : AuditableBaseEntity
    {
        
        public string inventoryName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public string bran { get; set; }

        //Sales
        public ICollection<Sales> sales { get; set; }
        
        //Category
        public int categoryID { get; set; }
        public Categories categories { get; set; }
    }
}
