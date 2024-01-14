using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
