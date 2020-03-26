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
    }
}
