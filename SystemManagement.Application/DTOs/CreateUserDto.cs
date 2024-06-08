namespace SystemManagement.Application.DTOs
{
    public class CreateUserDto 
    {
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
