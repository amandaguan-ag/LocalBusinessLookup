using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalBusinessLookup.Models;

namespace LocalBusinessLookup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly LocalBusinessLookupContext _db;

        public BusinessesController(LocalBusinessLookupContext db)
        {
            _db = db;
        }

        // GET api/businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> Get()
        {
            return await _db.Businesses.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(int id)
        {
            Business business = await _db.Businesses.FindAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }
    }
}