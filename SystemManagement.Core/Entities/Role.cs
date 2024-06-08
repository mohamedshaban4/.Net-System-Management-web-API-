﻿namespace SystemManagement.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}