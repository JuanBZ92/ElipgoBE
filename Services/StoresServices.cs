using ElipgoBE.DataSet;
using ElipgoBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Services
{
    public class StoresServices : IStoresServices
    {
        public readonly StoresDataSet _storesDataSet;

        public StoresServices(StoresDataSet storesDataSet)
        {
            _storesDataSet = storesDataSet;
        }
        public async Task<StoresResponseModel> GetAllStores()
        {
            return await _storesDataSet.GetAllStores();
        }

        public async Task<StoresResponseModel> UpdateStore(StoresInformation storesInformation)
        {
            return await _storesDataSet.UpdateStore(storesInformation);
        }

        public async Task<StoresResponseModel> AddStore(StoresInformation storesInformation)
        {
            return await _storesDataSet.AddStore(storesInformation);
        }
    }
}
