using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanHo.Models;

namespace CanHo.Controllers
{
    public class NhanVienController : Controller
    {

        public IActionResult Index()
        {
            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;
            return View(context.getTenNhanVien());
        }

        public IActionResult ListTB(string id)
        {
            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;
            return View(context.getListTB(id));
        }

        public IActionResult Edit(string id, string id1, string id2, int id3)
        {
            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;
            ViewData["NV_BT"] = context.getNVBT(id, id1, id2, id3);
            return View(context.getNVBT(id, id1, id2, id3));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string id1, string id2, int id3, NV_BT nv)
        {

            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;            
            if (context.Update(nv) != 0)
            {
                return Redirect("/NhanVien/ListTB?id="+nv.MaNV);
            }
            return Redirect("/NhanVien/ListTB?id=" +nv.MaNV);
        }

        public IActionResult Delete(string id, string id1, string id2, int id3)
        {
            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;
            if (context.Delete(id, id1, id2, id3) != 0)
            {
                return Redirect("/NhanVien/ListTB?id=" + id);
            }
            return Redirect("/NhanVien/ListTB?id=" +id);
        }

        public IActionResult Search(int id)
        {
            CanHoContext context = HttpContext.RequestServices.GetService(typeof(CanHo.Models.CanHoContext)) as CanHoContext;
            return View(context.getNhanVien(id));
        }
    }
}
