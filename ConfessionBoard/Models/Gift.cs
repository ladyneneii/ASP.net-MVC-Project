namespace ConfessionBoard.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public string GiftName { get; set; }
        public int Price { get; set; }
        public int QuantityLeft { get; set; }
        public string Status { get; set; }

        public Gift()
        {

        }
    }
}
