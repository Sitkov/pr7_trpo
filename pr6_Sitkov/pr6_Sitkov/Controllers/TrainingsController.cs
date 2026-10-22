using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pr6_Sitkov.Models;

namespace pr6_Sitkov.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly WebApiDatabaseContext db;

        public TrainingsController(WebApiDatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult GetAll ([FromQuery] string? trainer)
        {
            var query = db.Trainings.AsQueryable();

            if (!string.IsNullOrEmpty(trainer))
            {
                query = query.Where(t => t.Trainer.Contains(trainer));
            }
            var items = query.ToList();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get (int id)
        {
            var item = db.Trainings.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Create ([FromBody] Training training)
        {
            training.Id = 0;

            db.Trainings.Add(training);
            db.SaveChanges(); 

            return CreatedAtAction(nameof(Get), new { id = training.Id }, training);
        }


        [HttpPut("{id}")]
        public IActionResult Update (int id, Training training)
        {
            var existing = db.Trainings.Find(id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Title = training.Title;
            existing.Trainer = training.Trainer;
            existing.DurationMinutes = training.DurationMinutes;
            existing.Price = training.Price;
            existing.IsActive = training.IsActive;
            db.SaveChanges();
            return NoContent();
        }
        
         
        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Training tr)
        {
            var existing = db.Trainings.Find(id);
            if (existing == null)
            {
                return NotFound();
            }
            if (tr.Title != null)
                existing.Title = tr.Title;
            if (tr.Trainer != null)
                existing.Trainer = tr.Trainer;
            if (tr.DurationMinutes != null)
                existing.DurationMinutes = tr.DurationMinutes;
            if (tr.Price != null)
                existing.Price = tr.Price;
            if (tr.IsActive)
                existing.IsActive = tr.IsActive;
            db.SaveChanges();

            return NoContent();
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var existing = db.Trainings.Find(id);
            if (existing == null)
            {
                return NotFound();
            }
            db.Trainings.Remove(existing);
            db.SaveChanges();
            return NoContent();
        }
    }
}
