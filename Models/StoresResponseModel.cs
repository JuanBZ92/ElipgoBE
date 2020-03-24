using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Models
{
    public class StoresResponseModel
    {
        public IList<StoresInformation> Stores { get; set; }
        public bool Success { get; set; }
        public int Total_elements { get; set; }
        public static StoresResponseModel Map(IList<StoresInformation> storesInformation)
        {
            StoresResponseModel response = new StoresResponseModel();
            IList<StoresInformation> stores = new List<StoresInformation>();
            foreach(StoresInformation information in storesInformation)
            {
                stores.Add(StoresInformation.Map(information));
            }
            response.Stores = stores;
            response.Success = true;
            response.Total_elements = storesInformation.Count;
            return response;
        }
    }

    public class StoresInformation
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
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
    }
}
