using Data.Services.Constant;
using Data.Services.Extensions;
using Data.Services.Interface;
using Data.Services.Models;
using Data.Services.Response;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Services.Services
{
    public class TripService : ITripService
    {
        private readonly IFileService _fileService;
        public TripService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IEnumerable<DataSetDto>> GetTrips() 
        {
            var model = _fileService.ReadReturnJson();

            return await model;

        }

        public async Task<List<OptionDto>> RepairableBikes()
        {
            double totalMinutes = 0.0;
            List<OptionDto> model = new List<OptionDto>();
            var bikeItems = new OptionDto();
            try 
            {
                var json = await _fileService.ReadReturnJson();
                var bikeList = json.Select(x => x.bikeid).ToList().Distinct();
                foreach (var bikeId in bikeList) 
                {
                    var tripDurationSecList = json.Where(x=>x.bikeid == bikeId).Select(x => x.tripduration).ToList();
                    totalMinutes = tripDurationSecList.ReturnTotalMinutesTripDuration();
                    if (totalMinutes > Constants.RepairMinuteLimit)
                    {
                        bikeItems = new OptionDto 
                        {
                            id = (int)bikeId,
                            name = "bikeId"
                        };

                        model.Add(bikeItems);
                    }
                }

            } catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        public async Task<Option2Dto> RevenueFromStation(int code)
        {
            var revenueAmountJson = new Option2Dto();
            string revenueAmount = null;
            double totalMinutes = 0.0;
            try 
            {
                var json = await _fileService.ReadReturnJson();
                var stationData = json.Where(x => x.from_station_id == code).ToList();
                var tripDurationSecList = stationData.Select(x => x.tripduration).ToList();
                totalMinutes = tripDurationSecList.ReturnTotalMinutesTripDuration();
                revenueAmount = (Math.Round(totalMinutes * Constants.EarningPerMinute, 3)).ToString();
                revenueAmountJson = revenueAmount.Select(x => new Option2Dto
                {
                    Key = "revenue",
                    Value = revenueAmount
                }).FirstOrDefault();


            } catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return revenueAmountJson;
        }


        public async Task<dynamic> GetTopStations()
        {
            var topRevenueList = new List<StationRevenueDto>();
            double revenueAmount = 0.0;
            double totalMinutes = 0.0;
            try
            {
                var json = await _fileService.ReadReturnJson();
                var stationIdsList = json.Select(x => new { id = x.from_station_id, name = x.from_station_name }).Distinct().ToList().OrderBy(x => x.id);
                foreach (var station in stationIdsList)
                {
                    var stationData = json.Where(x => x.from_station_id == station.id).ToList();
                    var tripDurationSecList = stationData.Select(x => x.tripduration).ToList();
                    totalMinutes = tripDurationSecList.ReturnTotalMinutesTripDuration();
                    revenueAmount = (Math.Round(totalMinutes * Constants.EarningPerMinute, 3));
                    topRevenueList.Add(new StationRevenueDto { StationId = station.id, StationName = station.name, Revenue = revenueAmount });

                }
                topRevenueList = topRevenueList.OrderByDescending(x => x.Revenue).Take(3).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return topRevenueList;
        }
    }
}
