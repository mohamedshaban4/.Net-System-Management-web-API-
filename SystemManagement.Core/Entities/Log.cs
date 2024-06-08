namespace SystemManagement.Core.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public int UserId { get; set; }
        public string IpAddress { get; set; }
    }
}
