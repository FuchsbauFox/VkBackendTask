using System;
using Users.Domain.Enums;

namespace Users.Domain
{
    public class UserState
    {
        public Guid Id { get; set; }
        
        public User User { get; set; }
        
        public Status Code { get; set; }
        
        public string Description { get; set; }
    }
}
