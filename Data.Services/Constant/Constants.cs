using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Constant
{
    public static class Constants
    {
        public static string FileName = "dataset.json";
        #region Station Codes
        public static string FromStationTitleId = "from_station_id";
        public static string FromStationTitleString = "from_station_name";

        public static string ToStationTitleId= "to_station_id";
        public static string ToStationTitleString = "to_station_name";
        #endregion
        public static double EarningPerMinute = 0.10;
        public static double RepairMinuteLimit = 1000;
        public static double BikeRepairableSeconds = 60000;
    }
}
