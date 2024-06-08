namespace SystemManagement.Application.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}
