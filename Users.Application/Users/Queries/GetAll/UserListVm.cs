using System.Collections.Generic;
using Users.Application.Users.Queries.GetBy;

namespace Users.Application.Users.Queries.GetAll
{
    public class UserListVm
    {
        public IList<UserDetailsVm> Users { get; set; }
    }
}