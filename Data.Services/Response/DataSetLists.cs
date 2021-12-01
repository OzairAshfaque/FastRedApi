using Data.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Services.Response
{
    public class DataSetLists
    {

        public List<DataSetDto> DataSetList { get; set; }

        public DataSetLists() 
        {
            DataSetList = new List<DataSetDto>();
        }

    }
}
