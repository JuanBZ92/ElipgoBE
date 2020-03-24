using ElipgoBE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.DataSet
{
    public class ArticlesDataSet : IArticlesDataSet
    {
        private readonly MyDbContext _context;
        public ArticlesDataSet(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ArticlesResponseModel> GetAllArticles()
        {
            try
            {
                IList<ArticlesInformation> articlesInformation = await _context.Articles.ToListAsync();
                ArticlesResponseModel articlesResponseModel = ArticlesResponseModel.Map(articlesInformation);
                return articlesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ArticlesResponseModel> GetArticlesByStore(int id)
        {
            try
            {
                var response = await _context.Articles.Where(x => x.Store_Id == id).ToListAsync();
                ArticlesResponseModel articlesResponseModel = ArticlesResponseModel.Map(response);
                return articlesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ArticlesResponseModel> UpdateArticle(ArticlesInformation articlesInformation)
        {
            try
            {
                _context.Entry(articlesInformation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                IList<ArticlesInformation> _articlesInformation = await _context.Articles.ToListAsync();
                ArticlesResponseModel articlesResponseModel = ArticlesResponseModel.Map(_articlesInformation);
                return articlesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ArticlesResponseModel> AddArticle(ArticlesInformation articlesInformation)
        {
            try
            {
                _context.Articles.Add(articlesInformation);
                await _context.SaveChangesAsync();
                var response = await _context.Articles.Where(x => x.Store_Id == articlesInformation.Store_Id).ToListAsync();
                ArticlesResponseModel articlesResponseModel = ArticlesResponseModel.Map(response);
                return articlesResponseModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}