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
        public IList<ArticlesInformation> Articles { get; set; }
        public bool Success { get; set; }
        public int Total_Elements { get; set; }
        
        public static ArticlesResponseModel Map(IList<ArticlesInformation> articlesInformation)
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
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Total_In_Shelf { get; set; }
        [Required]
        public int Total_In_Vault { get; set; }
        [Required]
        [ForeignKey("Store_Id")]
        public int Store_Id { get; set; }
    }
}
