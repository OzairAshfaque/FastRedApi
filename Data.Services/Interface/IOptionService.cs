using Data.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interface
{
    public interface IOptionService
    {
        Task<int> GetFromStationCount();

        Task<OptionResponse> GetFromStationOption();
    }
}
