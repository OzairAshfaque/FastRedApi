using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Models
{
    class StationRevenueDto
    {
        public int? StationId { get; set; }
        public string StationName { get; set; }
        public double? Revenue { get; set; }
    }
}
