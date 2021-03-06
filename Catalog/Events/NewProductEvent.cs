﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Catalog.Events
{
    public class NewProductEvent
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatagoryId { get; set; }
        public string CatagoryCode { get; set; }
        public string CatagoryName { get; set; }
        public string CatagoryDesc { get; set; }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
