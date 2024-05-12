using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class Customer
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


    }
}
