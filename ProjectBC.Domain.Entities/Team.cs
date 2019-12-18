﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBC.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Members { get; set; }
    }
}
