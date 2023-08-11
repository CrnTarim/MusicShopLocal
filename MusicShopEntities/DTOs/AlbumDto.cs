using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.DTOs
{
    public class AlbumDto : BaseDto
    {    
        public string Singer { get; set; }   
        public string RecordCompanyName { get; set; }
        public int CustomerId { get; set; }
        public int CreatedYear { get; set; }
    }
}
