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

        [HttpGet]
        public ActionResult<IEnumerable<Business>> Get(string name, string address, string phoneNumber, string website)
        {
            var query = _db.Businesses.AsQueryable();

            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }

            if (address != null)
            {
                query = query.Where(entry => entry.Address == address);
            }

            if (phoneNumber != null)
            {
                query = query.Where(entry => entry.PhoneNumber == phoneNumber);
            }

            if (website != null)
            {
                query = query.Where(entry => entry.Website == website);
            }

            return query.ToList();
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
        // POST api/businesses
        [HttpPost]
        public async Task<ActionResult<Business>> Post(Business business)
        {
            _db.Businesses.Add(business);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId }, business);
        }
        // PUT: api/Businesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Business business)
        {
            if (id != business.BusinessId)
            {
                return BadRequest();
            }

            _db.Businesses.Update(business);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        private bool BusinessExists(int id)
        {
            return _db.Businesses.Any(e => e.BusinessId == id);
        }
        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            Business business = await _db.Businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            _db.Businesses.Remove(business);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}