using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.DTOs
{
    public class RecordCompanyDto : BaseDto
    {        
        public int CompanyYear { get; set; }
        public int CompanyValue { get; set; }
        public int AlbumId { get; set; }
    }
}
