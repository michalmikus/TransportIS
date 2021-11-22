﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.DAL.Entities
{
    public class StopEntity : BaseEntity
    {
        public string? Name     { get; set; }
        public string? Location { get; set; }

        public string? Address { get; set; }

        public EmploeeEntity? ResponsibleEmploee { get; set; }
    }
}
