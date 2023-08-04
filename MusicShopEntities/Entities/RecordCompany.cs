using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.Entities
{
    public class RecordCompany : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyYear { get; set; }
        public int CompanyValue { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
