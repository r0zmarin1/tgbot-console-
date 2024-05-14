using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class DrinkOrder
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Id_customer { get; set; }
        public Customer Customer { get; set; } = new();
        //public List<Drinks> Drinks {get; set; } = new();
        //public List<Adds> Adds { get; set; } = new();
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
