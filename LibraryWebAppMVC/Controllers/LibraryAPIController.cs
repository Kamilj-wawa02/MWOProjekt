using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryWebAppMVC.Library;
using LibraryWebAppMVC.Services.LibraryService;
using System.Diagnostics;

namespace LibraryWebAppMVC.Controllers
{
    public class LibraryAPIController : Controller
    {
      
        private readonly ILibraryService _libraryService;

        public LibraryAPIController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: Library
        public async Task<IActionResult> Index()
        {
            var books = _libraryService.GetBooks();
            return books != null ?
                          View(books.AsEnumerable()) :
                          Problem("Entity set 'LibraryContext.Library'  is null.");
        }

        // GET: Library/Details/5
        public async Task<IActionResult> Details(int? id)
        {
         
            if (id == null)
            {
                return NotFound();
            }
            var book = _libraryService.GetBookById((int)id);
            
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Library/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Library/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                _libraryService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Library/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var book = _libraryService.GetBookById((int)id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Library/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description")] Book book)
        {

            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productResult = _libraryService.UpdateBook(book);
                }
                catch (Exception)
                {
                     return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Library/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = _libraryService.GetBookById((int)id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = _libraryService.DeleteBook((int)id);
            if (book)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
          
        }
         
    }
}
