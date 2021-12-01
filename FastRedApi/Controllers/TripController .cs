using Data.Services.Extensions;
using Data.Services.Interface;
using Data.Services.Models;
using Data.Services.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FastRedApi.Controllers
{
   
    public class TripController : BaseApiController
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        [ActionName("gettrips")]
        public async Task<ActionResult> GetTripsList()
        {
            dynamic response = new List<ExpandoObject>();
            try 
            {
                response = _tripService.GetTrips();
                

            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);

            }
            return Ok( response);
           
        }

        [HttpGet]
        [ActionName("getrevenuefromstation")]
        public async Task<ActionResult> GetRevenueByFromStation(int code)
        {
            dynamic response = new List<ExpandoObject>();
            try
            {
                response = await _tripService.RevenueFromStation(code);


            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
            return Ok(response);

        }

        [HttpGet]
        [ActionName("gettopthreestations")]
        public async Task<ActionResult> GetTopRevenueStations()
        {
            dynamic response = new List<ExpandoObject>();
            try
            {
                response = await _tripService.GetTopStations();


            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
            return Ok(response);

        }


        [HttpGet]
        [ActionName("getrepairablebikes")]
        public async Task<ActionResult> GetRepairableBikes()
        {
            dynamic response = new List<ExpandoObject>();
            try
            {
                response = await _tripService.RepairableBikes();


            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
            return Ok(response);

        }
    }
}
