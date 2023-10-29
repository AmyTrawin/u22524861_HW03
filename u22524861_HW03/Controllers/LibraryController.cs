using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using u22524861_HW03.Models;

namespace u22524861_HW03.Controllers
{
    public class LibraryController : Controller
    {
        LibraryEntities context = new LibraryEntities();

        public async Task<ActionResult> Home(int? studentPage, int? bookPage)
        {
            var studentList = await context.students.ToListAsync();
            var bookList = await context.books.ToListAsync();
            var borrowList = await context.borrows.ToListAsync();

            int Size_Of_Page = 10;

            var studentPagedList = studentList.ToPagedList(studentPage ?? 1, Size_Of_Page) as IPagedList<students>;
            var bookPagedList = bookList.ToPagedList(bookPage ?? 1, Size_Of_Page) as IPagedList<books>;

            var completedList = new ViewModel
            {
                studentList = studentPagedList,
                bookList = bookPagedList,
                borrowList2 = borrowList
            };

            ViewBag.authorId = new SelectList(context.authors, "authorId", "name");
            ViewBag.typeId = new SelectList(context.types, "typeId", "name");

            return View(completedList);

        }

        public async Task<ActionResult> Maintain(int? authorPage, int? typePage, int? borrowPage)
        {
            var authorList = await context.authors.ToListAsync();
            var typeList = await context.types.ToListAsync();
            var borrowList = await context.borrows.ToListAsync();
            var studentLists = await context.students.ToListAsync();
            var bookLists = await context.books.ToListAsync();

            int Size_Of_Page = 10;

            var authorPagedList = authorList.ToPagedList(authorPage ?? 1, Size_Of_Page) as IPagedList<authors>;
            var typePagedList = typeList.ToPagedList(typePage ?? 1, Size_Of_Page) as IPagedList<types>;
            var borrowPagedList = borrowList.ToPagedList(borrowPage ?? 1, Size_Of_Page) as IPagedList<borrows>;

            var completedList = new ViewModel
            {
                authorList = authorPagedList,
                typeList = typePagedList,
                borrowList = borrowPagedList,
                studentList2 = studentLists,
                bookList2 = bookLists
            };

            ViewBag.bookId = new SelectList(context.books, "bookId", "name");
            ViewBag.studentId = new SelectList(context.students, "studentId", "name");

            return View(completedList);
        }

        public async Task<ActionResult> Report()
        {
            var borrowList = await context.borrows.ToListAsync();
            var studentList = await context.students.ToListAsync();
            var bookList = await context.books.ToListAsync();

            // Create the ViewModel
            var completedList = new ViewModel
            {
                borrowList2 = borrowList,
                studentList2 = studentList,
                bookList2 = bookList
            };
            return View(completedList);
        }

        public async Task<ActionResult> DeleteReport(string fileName)
        {
            var filePath = Path.Combine(Server.MapPath("~/Reports"), fileName);

            // Use asynchronous file deletion
            await Task.Run(() => System.IO.File.Delete(filePath));

            // Redirect to the Report action to refresh the page
            return RedirectToAction("Report");
        }
    }
}