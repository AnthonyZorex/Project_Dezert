using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Dezert.Data;
using Project_Dezert.Models;

namespace Project_Dezert.Controllers
{
    public class FriendsController : Controller
    {
        private readonly Project_DezertContext _context;

        public FriendsController(Project_DezertContext context)
        {
            _context = context;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            var project_DezertContext = _context.Friends.Include(f => f.User);
            return View(await project_DezertContext.ToListAsync());
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friends = await _context.Friends
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friends == null)
            {
                return NotFound();
            }

            return View(friends);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login");
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Messager,yourID")] Models.Friends friends)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friends);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login", friends.UserId);
            return View(friends);
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friends = await _context.Friends.FindAsync(id);
            if (friends == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login", friends.UserId);
            return View(friends);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Messager,yourID")] Models.Friends friends)
        {
            if (id != friends.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friends);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendsExists(friends.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login", friends.UserId);
            return View(friends);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friends = await _context.Friends
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friends == null)
            {
                return NotFound();
            }

            return View(friends);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Friends == null)
            {
                return Problem("Entity set 'Project_DezertContext.Friends'  is null.");
            }
            var friends = await _context.Friends.FindAsync(id);
            if (friends != null)
            {
                _context.Friends.Remove(friends);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendsExists(int id)
        {
          return (_context.Friends?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
