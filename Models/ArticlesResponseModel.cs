using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Models
{
    public class ArticlesResponseModel
    {
        public List<ArticlesInformation> Articles { get; set; }
        public bool Success { get; set; }
        public int Total_Elements { get; set; }
        
        public static ArticlesResponseModel Map(List<ArticlesInformation> articlesInformation)
        {
            return new ArticlesResponseModel
            {
                Articles = articlesInformation,
                Success = true,
                Total_Elements = articlesInformation.Count
            };
        }
    }


    public class ArticlesInformation
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public int? Total_In_Shelf { get; set; }
        public int? Total_In_Vault { get; set; }
        [ForeignKey("Store_Id")]
        public int? Store_Id { get; set; }

        public static ArticlesInformation MapUpdate(ArticlesInformation updated, ArticlesInformation original)
        {
            return new ArticlesInformation
            {
                Id = updated.Id,
                Description = updated.Description != string.Empty ? updated.Description : original.Description,
                Name = updated.Name != string.Empty ? updated.Name : original.Description,
                Price = updated.Price.HasValue ? updated.Price : original.Price,
                Total_In_Shelf = updated.Total_In_Shelf.HasValue ? updated.Total_In_Shelf : original.Total_In_Shelf,
                Total_In_Vault = updated.Total_In_Vault.HasValue ? updated.Total_In_Vault : original.Total_In_Vault,
                Store_Id = updated.Store_Id.HasValue ? updated.Store_Id : original.Store_Id
            };
        }
    }
}
