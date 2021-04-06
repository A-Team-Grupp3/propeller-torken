﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class Order
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int OurCustomer { get; set; } // customerID
        public int OurProduct { get; set; } // productID
        public int OrderSum { get; set; }
    }
}
