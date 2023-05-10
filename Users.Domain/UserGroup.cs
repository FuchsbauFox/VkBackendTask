using System;
using Users.Domain.Enums;

namespace Users.Domain
{
    public class UserGroup
    {
        public Guid Id { get; set; }
        
        public User User { get; set; }
        
        public Role Code { get; set; }
        
        public string Description { get; set; }
    }
}
