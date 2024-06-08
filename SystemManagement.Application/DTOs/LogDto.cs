namespace SystemManagement.Application.DTOs
{
    public class LogDto
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string IpAddress { get; set; }
    }
}
