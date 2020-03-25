using ElipgoBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.DataSet
{
    public interface IStoresDataSet
    {
        Task<StoresResponseModel> GetAllStores();
        Task<StoresResponseModel> UpdateStore(StoresInformation storesInformation, StoresInformation originalInformation);
        Task<StoresResponseModel> AddStore(StoresInformation storesInformation);
    }
}
