using System.Collections.Generic;
using System.Linq;
using BookLibraryExam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryExam.Controllers
{
    public class BooksController : Controller
    {

        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book One", Author = "Author A", ISBN = "1234567890123", PublicationYear = 2020 },
            new Book { Id = 2, Title = "Book Two", Author = "Author B", ISBN = "9876543210987", PublicationYear = 2018 }
        };

        // GET: /Books
        public IActionResult Index()
        {
            return View(books);
        }

        // POST: /Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book newBook)
        {
            if (!ModelState.IsValid)
            {

                return View("Index", books);
            }


            int newId = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            newBook.Id = newId;

            books.Add(newBook);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Edit/5
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            return View(book);
        }

        // POST: /Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book editedBook)
        {
            if (id != editedBook.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(editedBook);

            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            book.Title = editedBook.Title;
            book.Author = editedBook.Author;
            book.ISBN = editedBook.ISBN;
            book.PublicationYear = editedBook.PublicationYear;

            return RedirectToAction(nameof(Index));
        }

        // POST: /Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            books.Remove(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
