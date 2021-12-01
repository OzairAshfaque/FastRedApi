using Data.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Response
{
   
    public class OptionResponse
    {
        public List<OptionDto> Options { get; set; }
        public OptionResponse()
        {
            Options = new List<OptionDto>();
        }

       
    }
}
