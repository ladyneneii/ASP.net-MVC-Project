namespace ConfessionBoard.Models
{
    public class Confession
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public string Relationship { get; set; }
        public string Message { get; set; }
        public string RecipientLN { get; set; }
        public string RecipientFN { get; set; }
        public int GiftFK { get; set; }

        public Confession()
        {

        }
    }
}
