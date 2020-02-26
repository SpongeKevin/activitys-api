using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("/api/activitys")]
    public class ActivityController : ControllerBase
    {
        private readonly DbContext _db;
        public ActivityController(DbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAll()
        {
            var activitys = await _db.Activitys.ToListAsync();

            return activitys;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Get(long id)
        {
            var activity = await _db.Activitys.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        [HttpPost]
        public async Task Post(Activity activity)
        {
            _db.Activitys.Add(activity);
            await _db.SaveChangesAsync();
        }

        [HttpPost("{id}")]
        public async Task Post(Activity activity, long id)
        {
            var activitys = await _db.Activitys.FindAsync(id);

            activitys.Title = activity.Title;
            activitys.Location = activity.Location;
            activitys.StartTime = activity.StartTime;
            activitys.EndTime = activity.EndTime;
            activitys.Depiction = activity.Depiction;

            await _db.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var activity = await _db.Activitys.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _db.Activitys.Remove(activity);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}

