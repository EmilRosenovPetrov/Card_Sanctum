namespace Card_Sanctum.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BoosterListViewModel
    {
        public Guid Id { get; set; } 

        public string Edition { get; set; }

        public int Price { get; set; }
    }
}
