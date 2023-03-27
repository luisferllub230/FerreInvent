using Source.Core.Domain.Common;

namespace Source.Core.Domain.Entities
{
    public class Custumers : AuditableBaseEntity
    {
        
        public string custumerName { get; set; }
        public string custumerAddress { get; set; }
        public string custumerEmail { get; set; }

        //Sales
        public ICollection<Sales> sales { get; set; }
    }
}
