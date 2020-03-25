using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Models
{
    public class StoresResponseModel
    {
        public List<StoresInformation> Stores { get; set; }
        public bool Success { get; set; }
        public int Total_elements { get; set; }
        public static StoresResponseModel Map(List<StoresInformation> storesInformation)
        {
            StoresResponseModel response = new StoresResponseModel();
            response.Stores = storesInformation;
            response.Success = true;
            response.Total_elements = storesInformation.Count;
            return response;
        }
    }

    public class StoresInformation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        
        public static StoresInformation Map(StoresInformation storesInformation)
        {
            return new StoresInformation
            {
                Id = storesInformation.Id,
                Address = storesInformation.Address,
                Name = storesInformation.Name
            };
        }

        public static StoresInformation MapUpdate(StoresInformation storesInformation, StoresInformation originalInformation)
        {
            return new StoresInformation
            {
                Id = storesInformation.Id,
                Address = storesInformation.Address != string.Empty ? storesInformation.Address : originalInformation.Address,
                Name = storesInformation.Name != string.Empty ? storesInformation.Name : originalInformation.Name
            };
        }
    }
}
