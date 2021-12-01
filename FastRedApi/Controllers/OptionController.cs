using Data.Services.Interface;
using Data.Services.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRedApi.Controllers
{
    public class OptionController : BaseApiController 
    {
        private readonly IOptionService _optionService;
        public OptionController(IOptionService optionService) 
        {
            _optionService = optionService;
        }
        [HttpGet]
        [ActionName("getfromstationcount")]
        public async Task<ActionResult<int>> getFromStationTotalCount() 
        {
            int response = await _optionService.GetFromStationCount();
            return response;
        }

        [HttpGet]
        [ActionName("getfromstationoption")]
        public async Task<ActionResult<OptionResponse>> getFromStations() 
        {
            var response = new OptionResponse();
            try 
            {
                response = await _optionService.GetFromStationOption();

            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return response;

        }

    }
}
