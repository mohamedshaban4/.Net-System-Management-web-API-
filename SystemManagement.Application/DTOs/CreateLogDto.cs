namespace SystemManagement.Application.DTOs
{
    public class CreateLogDto
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}
