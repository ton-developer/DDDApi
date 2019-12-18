using System;

namespace ProjectBC.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User Owner { get; set; }
    }
}
