using NetBanking.Core.Domain.Common;

namespace NetBanking.Core.Domain.Entities
{
    public class Loan: BasicEntity
    {
        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public double Installment {  get; set; }
        public byte PaymentDay { get; set; }
        public byte ProductType { get; set; }

        public ICollection<Payment> Payments { get; set; }


    }
}
