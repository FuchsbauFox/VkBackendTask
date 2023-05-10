﻿using System;

namespace Users.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid UserGroupId { get; set; }
        
        public UserGroup UserGroup { get; set; }
        
        public Guid UserStateId { get; set; }
        
        public virtual UserState UserState { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
