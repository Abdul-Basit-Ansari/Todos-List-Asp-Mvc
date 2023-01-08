using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosList.Models;
using TodosList.Data;

namespace TodosList.Controllers;
public class TodosController : Controller
{
    private readonly TodosContext _context;

    public TodosController(TodosContext context)
    {
        _context = context;
    }
    // GET: Todos
    public async Task<IActionResult> Index()
    {
        return _context.Todos != null ?
                    View(await _context.Todos.ToListAsync()) :
                    Problem("Entity set 'MvcMovieContext.Movie'  is null.");
    }

    // GET: Todos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Todos == null)
        {
            return NotFound();
        }

        var movie = await _context.Todos
            .FirstOrDefaultAsync(m => m.id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // GET: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,Title,Desc")] Todos todo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }


    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Todos == null)
        {
            return NotFound();
        }

        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,Title,Desc")] Todos todo)
    {
        if (id != todo.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.id))
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
        return View(todo);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Todos == null)
        {
            return NotFound();
        }

        var todo = await _context.Todos
            .FirstOrDefaultAsync(m => m.id == id);
        if (todo == null)
        {
            return NotFound();
        }

        return View(todo);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Todos == null)
        {
            return Problem("Entity set 'TodosContext.Todos'  is null.");
        }
        var movie = await _context.Todos.FindAsync(id);
        if (movie != null)
        {
            _context.Todos.Remove(movie);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool TodoExists(int id)
    {
        return (_context.Todos?.Any(e => e.id == id)).GetValueOrDefault();
    }

}
