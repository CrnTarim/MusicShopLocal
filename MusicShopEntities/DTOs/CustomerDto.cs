﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.DTOs
{
    public class CustomerDto : BaseDto { 
              
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
