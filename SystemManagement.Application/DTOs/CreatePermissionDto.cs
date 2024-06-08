namespace SystemManagement.Application.DTOs
{
    public class CreatePermissionDto
    {
        public int? UserId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
