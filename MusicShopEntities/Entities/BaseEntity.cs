﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopEntities.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public void UpdateModifiedDate()
        {
            UpdatedDate = DateTime.Now;
        }
    }

}