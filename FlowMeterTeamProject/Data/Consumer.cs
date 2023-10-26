﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMeterTeamProject.Data
{
    public class Consumer
    {
        [Key]
        public int ConsumersId { get; set; }
        public string PersonalAccount { get; set; }
        public int? Flat { get; set; }
        public string ConsumerOwner { get; set; }
        public int? HeatingArea { get; set; }
    }
}
