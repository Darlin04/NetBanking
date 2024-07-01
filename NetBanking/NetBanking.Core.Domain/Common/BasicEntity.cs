

namespace NetBanking.Core.Domain.Common
{
    public class BasicEntity : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
