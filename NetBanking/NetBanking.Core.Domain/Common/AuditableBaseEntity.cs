

namespace NetBanking.Core.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string? LastModifiedBy { get; set; }
        public virtual DateTime? LastModified { get; set; }
    }
}
