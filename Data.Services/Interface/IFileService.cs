using Data.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interface
{
    public interface IFileService
    {
        Task<IEnumerable<DataSetDto>> ReadReturnJson();
    }
}
