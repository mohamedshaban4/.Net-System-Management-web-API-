using SystemManagement.Core.Entities;

public class Permission
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
}
