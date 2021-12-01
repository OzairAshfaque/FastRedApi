using Data.Services.Interface;
using Data.Services.Models;
using Data.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Services
{
    public class OptionService : IOptionService
    {
        private readonly IFileService _fileService;
        public OptionService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<int> GetFromStationCount()
        {
            var JsonList = await _fileService.ReadReturnJson();
            return JsonList.Where(x => x.from_station_id != null).Select(x => x.from_station_id).Count();
        }

        public async Task<OptionResponse> GetFromStationOption()
        {
            var model = new OptionResponse();
            var JsonList = await _fileService.ReadReturnJson();
            model.Options = JsonList.Where(x => x.from_station_id != null)
                            .Select(x => new { x.from_station_id,x.from_station_name})
                            .ToList().Distinct()
                            .OrderBy(x=>x.from_station_id)
                            .Select(x=> new OptionDto 
                            {
                                id = (int)x.from_station_id,
                                name = x.from_station_name
                            }).ToList(); 
           
            return model;
            
        }
    }
}
