﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStrata.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}