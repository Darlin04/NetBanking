using NetBanking.Core.Domain.Common;


namespace NetBanking.Core.Domain.Entities
{
    public class Payment : BasicEntity
    {
        public int From { get; set; }
        public int To { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Type { get; set; }

        //Navigation Property

        public SavingsAccount FromAccount { get; set; }
    }
}
