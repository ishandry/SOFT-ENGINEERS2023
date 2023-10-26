﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeterTeamProject.Data
{
    public class House
    {
        [Key]
        public int HouseId { get; set; }
        public string HouseAddress { get; set; }
        public int? HeatingAreaOfHouse { get; set; }
        public int? NumberOfFlat { get; set; }
        public int? NumberOfResidents { get; set; }
    }
}
