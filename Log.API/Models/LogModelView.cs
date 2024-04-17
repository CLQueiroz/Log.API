namespace Log.API.Models
{
    public class LogModelView
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public long? User_ID { get; set; }
        public long? Company_ID { get; set; }
        public DateTime DTREPLIC { get; set; }
        public int CHDELECAO { get; set; }
    }
}
