namespace Card_Sanctum.Core.Models
{
    using Card_Sanctum.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CardPagingViewModel
    {      
        public int PageNumber { get; set; }

        public int TotalRecords { get; set; }

        public int PageSize { get; set; }

        public List<Card> Cards { get; set; }
    }
}
