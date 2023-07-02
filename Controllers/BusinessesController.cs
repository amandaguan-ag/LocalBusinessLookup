using Microsoft.AspNetCore.Mvc;
using LocalBusinessLookup.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBusinessLookup.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/businesses")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private LocalBusinessLookupContext _db;

        public BusinessesController(LocalBusinessLookupContext db)
        {
            _db = db;
        }

        // GET: api/Businesses
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

    //allow more advanced search options: partial match search
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/businesses")]
    [ApiController]
    public class BusinessesV2Controller : ControllerBase
    {
        private LocalBusinessLookupContext _db;

        public BusinessesV2Controller(LocalBusinessLookupContext db)
        {
            _db = db;
        }

        // GET: api/Businesses
        [HttpGet]
        public ActionResult<IEnumerable<Business>> Get(string name, string address, string phoneNumber, string website)
        {
            var query = _db.Businesses.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(entry => entry.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(entry => entry.Address.Contains(address));
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query = query.Where(entry => entry.PhoneNumber.Contains(phoneNumber));
            }

            if (!string.IsNullOrEmpty(website))
            {
                query = query.Where(entry => entry.Website.Contains(website));
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