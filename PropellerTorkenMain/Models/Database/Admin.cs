﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
