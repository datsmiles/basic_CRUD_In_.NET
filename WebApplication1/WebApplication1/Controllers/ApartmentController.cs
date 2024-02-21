using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Domain.Entities;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly MyDbContext _myDbContext;
        public ApartmentController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Apartments>> getAllApartments() 
        {
            return _myDbContext.Apartments;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartments?>> getByApartmentId(int id)
        {
            return await _myDbContext.Apartments.Where(x => x.Id == id).SingleOrDefaultAsync();      
        }
        [HttpPost]
        public async Task<ActionResult> createApartment(Apartments apartments)
        {
            await _myDbContext.Apartments.AddAsync(apartments);
            await _myDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(getByApartmentId), new {id=apartments.Id}, apartments);

           // return View(apartments);
        }
        [HttpPut]
        public async Task<ActionResult> updateApartment(Apartments apartments)
        {
             _myDbContext.Apartments.Update(apartments);
            await _myDbContext.SaveChangesAsync();
            return Ok();

            // return View(apartments);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var getApartById = await getByApartmentId(id);
            if(getApartById.Value == null)
                return NotFound("Apartment dose not exist");
            
            _myDbContext.Remove(getApartById.Value);
            await _myDbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
