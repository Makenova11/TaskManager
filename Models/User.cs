using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string SecondName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long Salt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
