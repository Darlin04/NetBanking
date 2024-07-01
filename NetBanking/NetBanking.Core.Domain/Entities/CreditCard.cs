using NetBanking.Core.Domain.Common;


namespace NetBanking.Core.Domain.Entities
{
    public class CreditCard: BasicEntity
    {
        public double Balance {  get; set; }
        public double Limit {  get; set; }
        public byte CutoffDay { get; set; }
        public byte PaymentDay { get; set; }
        public byte ProductType { get; set; }

        //Navigation Property

        public ICollection<Payment> Payments { get; set; }
    }
}
