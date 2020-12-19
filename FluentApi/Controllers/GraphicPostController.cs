using FluentApi.Common;
using FluentApi.Data;
using FluentApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Create(GraphicPost category)
        {
            if (ModelState.IsValid)
            {
                _db.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: GraphicPostController/Edit/5
        public async Task<IActionResult> Upsert(int? id)
        {
            try
            {
                GraphicPost obj = new GraphicPost();
                //For Insert
                if (id == null)
                {
                    return View(obj);
                }

                //For Update
                obj = await _db.GraphicPosts.FirstOrDefaultAsync(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }

                return View(obj);
            }
            catch
            {
                return View();
            }
        }

        // POST: GraphicPostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GraphicPost obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    //This is Create
                    await _db.GraphicPosts.AddAsync(obj);
                }
                else
                {
                    //This is an Update
                    _db.GraphicPosts.Update(obj);
                }
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: GraphicPostController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objList = await _db.GraphicPosts.FindAsync(id);
            if (objList == null)
            {
                return NotFound();
            }
            return View(objList);
        }

        // POST: GraphicPostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GraphicPost obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.GraphicPosts.Update(obj);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(obj.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        private bool CategoryExists(int id)
        {
            return _db.GraphicPosts.Any(e => e.Id == id);
        }

        // GET: GraphicPostController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objList = await _db.GraphicPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (objList == null)
            {
                return NotFound();
            }

            return View(objList);
        }

        // POST: GraphicPostController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objList = await _db.GraphicPosts.FindAsync(id);
            _db.GraphicPosts.Remove(objList);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
