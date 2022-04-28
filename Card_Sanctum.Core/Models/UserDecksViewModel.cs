namespace Card_Sanctum.Core.Models
{
    using Card_Sanctum.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserDecksViewModel
    {
        public string UserId { get; set; }

        public string CardId { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string[] DeckNames { get; set; }
    }
}
