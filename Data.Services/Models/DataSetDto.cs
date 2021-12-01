using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.Models
{
   public class DataSetDto
    {
        public int? trip_id { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public int? bikeid { get; set; }
        public string tripduration { get; set; }
        public int? from_station_id { get; set; }
        public string from_station_name { get; set; }
        public int? to_station_id { get; set; }
        public string to_station_name { get; set; }
        public string gender  { get; set; }
        public int? birthyear { get; set; }


    }
}
