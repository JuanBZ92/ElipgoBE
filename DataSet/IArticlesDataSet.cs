using ElipgoBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.DataSet
{
    public interface IArticlesDataSet
    {
        Task<ArticlesResponseModel> GetAllArticles();
        Task<ArticlesResponseModel> GetArticlesByStore(int id);
        Task<ArticlesResponseModel> UpdateArticle(ArticlesInformation articlesInformation);
        Task<ArticlesResponseModel> AddArticle(ArticlesInformation articlesInformation);
    }
}
