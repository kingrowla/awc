using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using awc.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace awc.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {

        private AWContext db = new AWContext();
        // GET: /<controller>/
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var customers = db.Customer.OrderByDescending(u => u.FirstName).Take(5);
            return View(customers.ToList());
        }
    }
}
