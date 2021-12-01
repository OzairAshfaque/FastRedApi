using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Services.Extensions
{
    public static class ExtensionMethods
    {
        public static string ReturnFileInString(this string filePath) 
        {
            string json = null;
            if (filePath != null) 
            {
                try 
                {
                     json = File.ReadAllText(filePath).Trim();
                    

                }
                catch (Exception ex) 
                {
                    throw new Exception(ex.Message);
                }
                

            }
            return json;

        }

        public static double ReturnTotalMinutesTripDuration(this List<string> tripDurationSecondList)
        {

            double totalTimeMinutes = 0;
            var secondIntList = tripDurationSecondList.Select(double.Parse).ToList().Sum();

            totalTimeMinutes = secondIntList / 60;
            return totalTimeMinutes;
        }
    }
}
