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
                List<ArticlesInformation> articlesInformation = await _context.Articles.ToListAsync();
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
                ArticlesResponseModel response = new ArticlesResponseModel();
                var list = await (from d in _context.Articles
                            where d.Store_Id == id
                            select new ArticlesInformation()
                            {
                                Id = d.Id,
                                Description = d.Description,
                                Name = d.Name,
                                Price = d.Price,
                                Store_Id = d.Store_Id,
                                Total_In_Shelf = d.Total_In_Shelf,
                                Total_In_Vault = d.Total_In_Vault
                            }).ToListAsync();
                response = ArticlesResponseModel.Map(list);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ArticlesResponseModel> UpdateArticle(ArticlesInformation articlesInformation, ArticlesInformation originalInformation)
        {
            try
            {
                var updateInfo = ArticlesInformation.MapUpdate(articlesInformation, originalInformation);
                _context.Entry(updateInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                List<ArticlesInformation> _articlesInformation = await _context.Articles.Where(x => x.Id == articlesInformation.Id).ToListAsync();
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
                List<ArticlesInformation> response = await _context.Articles.Where(x => x.Store_Id == articlesInformation.Store_Id).ToListAsync();
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