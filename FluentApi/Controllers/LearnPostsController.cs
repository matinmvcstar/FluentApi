using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FluentApi.Data;
using FluentApi.Models;

namespace FluentApi.Controllers
{
    public class LearnPostsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LearnPostsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: LearnPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.LearnPosts.Include(l => l.Customer).Include(l => l.LCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LearnPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnPost = await _db.LearnPosts
                .Include(l => l.Customer)
                .Include(l => l.LCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learnPost == null)
            {
                return NotFound();
            }

            return View(learnPost);
        }

        // GET: LearnPosts/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "Id");
            ViewData["LCategoryId"] = new SelectList(_db.LCategories, "Id", "CategoryName");
            return View();
        }

        // POST: LearnPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Image2,Video,Header,Text,Text2,Text3,CreateSlide,Active,CustomerId,LCategoryId")] LearnPost learnPost)
        {
            if (ModelState.IsValid)
            {
                _db.Add(learnPost);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "Id", learnPost.CustomerId);
            ViewData["LCategoryId"] = new SelectList(_db.LCategories, "Id", "CategoryName", learnPost.LCategoryId);
            return View(learnPost);
        }

        // GET: LearnPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnPost = await _db.LearnPosts.FindAsync(id);
            if (learnPost == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "Id", learnPost.CustomerId);
            ViewData["LCategoryId"] = new SelectList(_db.LCategories, "Id", "CategoryName", learnPost.LCategoryId);
            return View(learnPost);
        }

        // POST: LearnPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Image2,Video,Header,Text,Text2,Text3,CreateSlide,Active,CustomerId,LCategoryId")] LearnPost learnPost)
        {
            if (id != learnPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(learnPost);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnPostExists(learnPost.Id))
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
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "Id", learnPost.CustomerId);
            ViewData["LCategoryId"] = new SelectList(_db.LCategories, "Id", "CategoryName", learnPost.LCategoryId);
            return View(learnPost);
        }

        // GET: LearnPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnPost = await _db.LearnPosts
                .Include(l => l.Customer)
                .Include(l => l.LCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learnPost == null)
            {
                return NotFound();
            }

            return View(learnPost);
        }

        // POST: LearnPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learnPost = await _db.LearnPosts.FindAsync(id);
            _db.LearnPosts.Remove(learnPost);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnPostExists(int id)
        {
            return _db.LearnPosts.Any(e => e.Id == id);
        }
    }
}
