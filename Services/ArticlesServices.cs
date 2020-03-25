using ElipgoBE.DataSet;
using ElipgoBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Services
{
    public class ArticlesServices : IArticlesServices
    {
        public readonly ArticlesDataSet _articlesDataSet;

        public ArticlesServices(ArticlesDataSet articlesDataSet)
        {
            _articlesDataSet = articlesDataSet;
        }
        public async Task<ArticlesResponseModel> GetAllArticles()
        {
            return await _articlesDataSet.GetAllArticles();
        }

        public async Task<ArticlesResponseModel> GetArticlesByStore(int id)
        {
            return await _articlesDataSet.GetArticlesByStore(id);
        }

        public async Task<ArticlesResponseModel> UpdateArticle(ArticlesInformation articlesInformation, ArticlesInformation originalInformation)
        {
            return await _articlesDataSet.UpdateArticle(articlesInformation, originalInformation);
        }

        public async Task<ArticlesResponseModel> AddArticle(ArticlesInformation articlesInformation)
        {
            return await _articlesDataSet.AddArticle(articlesInformation);
        }
    }
}
