using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WallboardBack.Models;

namespace WallboardBack.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : Controller
    {
        private readonly WallboardContext _context;

        public WidgetsController(WallboardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Widget> GetAll()
        {
            return _context.Widgets.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Widget item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Widgets.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetWidget", new { id = item.Id }, item);
        }

        [HttpGet("{id}", Name = "GetWidget")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.Widgets.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Widget item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var widget = _context.Widgets.FirstOrDefault(t => t.Id == id);
            if (widget == null)
            {
                return NotFound();
            }

            widget.Uri = item.Uri;
            widget.Name = item.Name;

            _context.Widgets.Update(widget);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var widget = _context.Widgets.FirstOrDefault(t => t.Id == id);
            if (widget == null)
            {
                return NotFound();
            }

            _context.Widgets.Remove(widget);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}