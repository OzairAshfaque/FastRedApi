using Data.Services.Models;
using Data.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interface
{
    public interface ITripService
    {
        Task<IEnumerable<DataSetDto>> GetTrips();
        Task<Option2Dto> RevenueFromStation(int code);
        Task<List<OptionDto>> RepairableBikes();
        Task<dynamic> GetTopStations();


    }
}
