using Source.Core.Domain.ICommon;

namespace Source.Core.Domain.Common


{
    public class AuditableBaseEntity : IdEntityCommon
    {
        public virtual int id { get; set; }
        public string createBy { get; set; }
        public DateTime created { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime? lastMoified { get; set; }
    }
}
