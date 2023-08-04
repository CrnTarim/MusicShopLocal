using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public string Singer { get; set; }
        public int CreatedYear { get; set; }
        public string RecordCompanyName { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public RecordCompany RecordCompany { get; set; }

    }
}
