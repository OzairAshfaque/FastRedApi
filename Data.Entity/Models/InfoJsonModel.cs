using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity.Models
{
   public class InfoJsonModel
    {
        public DateTime DateTime { get; set; }
        public string TempratureCenti { get; set; }
        public string TempratureFarhen { get; set; }
        public string Summary { get; set; }
    }
}
