﻿using ElipgoBE.Models;
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
            try
            {
                IList<StoresInformation> storesInformation = await _context.Stores.ToListAsync();
                StoresResponseModel storesResponseModel = StoresResponseModel.Map(storesInformation);
                return storesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<StoresResponseModel> UpdateStore(StoresInformation storesInformation)
        {
            try
            {
                _context.Entry(storesInformation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                IList<StoresInformation> _storesInformation = await _context.Stores.ToListAsync();
                StoresResponseModel storesResponseModel = StoresResponseModel.Map(_storesInformation);
                return storesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<StoresResponseModel> AddStore(StoresInformation storesInformation)
        {
            try
            {
                _context.Stores.Add(storesInformation);
                await _context.SaveChangesAsync();
                var response = await _context.Stores.Where(x => x.Id == storesInformation.Id).ToListAsync();
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
