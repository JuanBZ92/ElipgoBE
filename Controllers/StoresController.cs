using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElipgoBE.Models;
using ElipgoBE.Services;

namespace ElipgoBE.Controllers
{
    [Route("api/services/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        public readonly StoresServices _storeServices;
        private readonly MyDbContext _context;

        public StoresController(StoresServices storeServices, MyDbContext myDbContext)
        {
            _storeServices = storeServices;
            _context = myDbContext;
        }

        // GET: api/StoresInformations
        [HttpGet]
        public async Task<IActionResult> GetStoresInformation()
        {
            try
            {
                return Ok(await _storeServices.GetAllStores());
            }
            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Map(e));
            }
        }

        // PUT: api/StoresInformations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("UpdateStore")]
        public async Task<IActionResult> UpdateStore(int id, StoresInformation storesInformation)
        {
            // find store if note return error
            var findStore = _context.Stores.Find(id);
            if (findStore == null)
            {
                return NotFound();
            }
            //detach for later use
            _context.Entry(findStore).State = EntityState.Detached;
            try
            {
                var response = await _storeServices.UpdateStore(storesInformation, findStore);
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Map(e));
            }
        }

        // POST: api/StoresInformations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("AddStore")]
        public async Task<IActionResult> AddStore(StoresInformation storesInformation)
        {
            try
            {
                var response = await _storeServices.AddStore(storesInformation);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Map(e));
            }
        }
    }
}
