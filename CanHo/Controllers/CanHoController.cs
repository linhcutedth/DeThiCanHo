using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanHo.Models;

namespace CanHo.Controllers
{
    public class CanHoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CanHoModel();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CanHoModel ch)
        {
            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;
            if (context.Create(ch) != 0)
            {
                return View();
            }
            return View();
        }

    }
}
