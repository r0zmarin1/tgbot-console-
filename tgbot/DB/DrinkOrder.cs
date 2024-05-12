﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class DrinkOrder
    {
        public int Id { get; set; }
        public List<Status> Status { get; set; } = new();
        public List<Customer> Customer { get; set; } = new();
    }
}
