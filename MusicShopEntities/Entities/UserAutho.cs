using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.Entities
{
    public class UserAutho
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordSalt { get; set; }
    }
}
