using NetBanking.Core.Domain.Common;


namespace NetBanking.Core.Domain.Entities
{
    public class SavingsAccount: BasicEntity
    {
        public int Balance { get; set; }
        public bool IsPrincipal { get; set; }
        public string ProductType { get; set; }
        
        //Navigation Property

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Beneficiary> Beneficiaries { get;}
    }
}
