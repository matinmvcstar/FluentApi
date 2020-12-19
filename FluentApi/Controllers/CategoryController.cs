using FluentApi.Data;
using FluentApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> objList = await _db.Categories.ToListAsync();
            return View(objList);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            Category obj = new Category();
            //For Insert
            if (id == null)
            {
                return View(obj);
            }

            //For Update
            obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if(ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    //This is Create
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //This is an Update
                    _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _db.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            //ذخیره دوم
            List<Category> catlist = new List<Category>();
            //
            for(int i = 1; i <= 2; i++)
            {
                //ذخیره دوم
                catlist.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
                //ذخیره اول
                //await _db.Categories.AddAsync(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            //ذخیره دوم
            await _db.Categories.AddRangeAsync(catlist);
            //
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            for (int i = 1; i <= 5; i++)
            {
                await _db.Categories.AddAsync(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            //ذخیره دوم
            IEnumerable<Category> catlist = await _db.Categories.OrderByDescending(u => u.Id).Take(2).ToListAsync();
            //
            //ذخیره دوم
            _db.Categories.RemoveRange(catlist);
            //
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            //ذخیره دوم
            IEnumerable<Category> catlist = await _db.Categories.OrderByDescending(u => u.Id).Take(5).ToListAsync();
            //
            //ذخیره دوم
            _db.Categories.RemoveRange(catlist);
            //
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
