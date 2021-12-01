using Data.Services.Constant;
using Data.Services.Extensions;
using Data.Services.Interface;
using Data.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Services.Services
{
    public class FileService : IFileService
    {
        public async Task<IEnumerable<DataSetDto>> ReadReturnJson()
        {
            var filePath = Constants.FileName;
            var json = filePath.ReturnFileInString();
            var model =  JsonSerializer.Deserialize<IEnumerable<DataSetDto>>(json);
            return model;

        }
    }
}
