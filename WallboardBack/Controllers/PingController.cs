using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WallboardBack.Models;

namespace WallboardBack.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        public PingController()
        {
        }

        [HttpGet]
        public DateTime Ping()
        {
            return DateTime.Now;
        }
    }
}