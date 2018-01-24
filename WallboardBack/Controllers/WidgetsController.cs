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
        private readonly WallboardContext _context;

        public WidgetsController(WallboardContext context)
        {
            _context = context;

            if (_context.Widgets.Count() == 0)
            {
                _context.Widgets.Add(new Widget { Name = "Google Calendar", Uri = "/widgets/google-calendar/index.html" });
                _context.Widgets.Add(new Widget { Name = "Twitter", Uri = "/widgets/twitter/index.html" });
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