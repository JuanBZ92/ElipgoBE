using ElipgoBE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.DataSet
{
    public class StoresDataSet : IStoresDataSet
    {
        private readonly MyDbContext _context;
        public StoresDataSet(MyDbContext context)
        {
            _context = context;
        }

        public async Task<StoresResponseModel> GetAllStores()
        {
            // get all stores using ef code first context
            try
            {
                List<StoresInformation> storesInformation = await _context.Stores.ToListAsync();
                StoresResponseModel storesResponseModel = StoresResponseModel.Map(storesInformation);
                return storesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<StoresResponseModel> UpdateStore(StoresInformation storesInformation, StoresInformation originalInformation)
        {
            // update store using context and returning info with linq
            try
            {
                var updateInfo = StoresInformation.MapUpdate(storesInformation, originalInformation);
                StoresResponseModel response = new StoresResponseModel();
                _context.Entry(updateInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var list = await (from d in _context.Stores
                            select new StoresInformation()
                            {
                                Id = d.Id,
                                Address = d.Address,
                                Name = d.Name
                            }).ToListAsync();
                response = StoresResponseModel.Map(list);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<StoresResponseModel> AddStore(StoresInformation storesInformation)
        {
            //add store using context and returning info with lambdas and context.
            try
            {
                _context.Stores.Add(storesInformation);
                await _context.SaveChangesAsync();
                List<StoresInformation> response = await _context.Stores.Where(x => x.Id == storesInformation.Id).ToListAsync();
                StoresResponseModel storesResponseModel = StoresResponseModel.Map(response);
                return storesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
