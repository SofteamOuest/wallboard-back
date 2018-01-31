using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WallboardBack.Models;

namespace WallboardBack.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : Controller
    {
        private readonly IWallboardContext _context;

        public WidgetsController(IWallboardContext context)
        {
            _context = context;

            if (_context.Widgets.Count() == 0)
            {
                _context.Widgets.Add(new Widget { Name = "Google Calendar", Uri = "/google-calendar/index.html" });
                _context.Widgets.Add(new Widget { Name = "Twitter", Uri = "/twitter/index.html" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Widget> GetAll()
        {
            return _context.Widgets.ToList();
        }
    }
}