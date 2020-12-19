using FluentApi.Data;
using FluentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Controllers
{
    public class GraphicPostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GraphicPostController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: GraphicPostController
        public async Task<IActionResult> Index()
        {
            List<GraphicPost> objList = await _db.GraphicPosts.ToListAsync();
            return View(objList);
        }

        // GET: GraphicPostController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var GraphicList = await _db.GraphicPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (GraphicList == null)
            {
                return NotFound();
            }

            return View(GraphicList);
        }

        // GET: GraphicPostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GraphicPostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GraphicPostController/Edit/5
        public ActionResult Upsert(int id)
        {
            return View();
        }

        // POST: GraphicPostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GraphicPostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GraphicPostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GraphicPostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GraphicPostController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
