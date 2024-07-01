using NetBanking.Core.Domain.Common;


namespace NetBanking.Core.Domain.Entities
{
    public class Beneficiary : AuditableBaseEntity
    {
        public string UserUserName { get; set; }
        public string BeneficiaryUserName {  get; set; }
        public int AccountNumber { get; set; }


        //Navigation Properties
        public  SavingsAccount SavingsAccount  { get; set;}

    }
}
