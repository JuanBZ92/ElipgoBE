using ElipgoBE.Models;
using ElipgoBE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Controllers
{
    [Route("api/services/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;
        public readonly LoginService _loginService;
        public LoginController(MyDbContext context, LoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }

        // GET: api/Login/
        [HttpGet("GetAccess")]
        public async Task<IActionResult> GetAccess(string username, string password)
        {
            if (username == string.Empty || password == string.Empty)
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
                var response = await _loginService.login(username, password);
                return Ok(response);
            }
            catch (Exception e)
            {
                return NotFound(ErrorResponse.Map(e));
            }
        }

        // PUT: api/Login/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginModel(int id, LoginModel loginModel)
        {
            if (id != loginModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LoginModel>> PostLoginModel(LoginModel loginModel)
        {
            _context.Login.Add(loginModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginModel", new { id = loginModel.Id }, loginModel);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginModel>> DeleteLoginModel(int id)
        {
            var loginModel = await _context.Login.FindAsync(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            _context.Login.Remove(loginModel);
            await _context.SaveChangesAsync();

            return loginModel;
        }

        private bool LoginModelExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}
