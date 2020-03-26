using ElipgoBE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ElipgoBE.Models
{
    [Route("api/services/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ArticlesController : ControllerBase
    {
        public readonly ArticlesServices _articlesServices;
        public readonly LoginService _loginService;
        private readonly MyDbContext _context;
        public ArticlesController(ArticlesServices articlesServices, MyDbContext context)
        {
            _articlesServices = articlesServices;
            _context = context;
        }

        // GET: api/ArticlesInformations
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            try
            {
                return Ok(await _articlesServices.GetAllArticles());
            }
            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Map(e)) ;
            }
        }

        // GET: api/ArticlesInformations/5
        [HttpGet("stores/{id}")]
        public async Task<IActionResult> GetArticlesByStore(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse()
                {
                    Success = false,
                    Error_Code = 400,
                    Error_Message = "Bad Request"
                });
            }

            try
            {
                return Ok(await _articlesServices.GetArticlesByStore(id));
            }
            catch (Exception e)
            {
                return NotFound(ErrorResponse.Map(e));
            }
        }

        // PUT: api/ArticlesInformations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle(int id, ArticlesInformation articlesInformation)
        {
            // find article to update if not return not found
            var findArticle = _context.Articles.Find(id);
            if (findArticle == null)
            {
                return NotFound();
            }
            // detach to use again later on dataset
            _context.Entry(findArticle).State = EntityState.Detached;
            try
            {
                return Ok(await _articlesServices.UpdateArticle(articlesInformation, findArticle));
            }
            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Map(e));
            }
        }

        // POST: api/ArticlesInformations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticle(ArticlesInformation articlesInformation)
        {
            // find store to add article if not return not found
            var findStore = _context.Stores.Find(articlesInformation.Store_Id);
            if (findStore == null)
            {
                return NotFound();
            }

            try
            {
                var response = await _articlesServices.AddArticle(articlesInformation);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Map(e));
            }
        }
    }
}
