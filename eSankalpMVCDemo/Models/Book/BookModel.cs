using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankalpMVCDemo.Data;

namespace eSankalpMVCDemo.Models
{
    public class BookModel
    {
        public long BookID { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }

        public string SaveBook(BookModel model)
        {
            string msg = "";
            eSankalpMVCDemoEntities db = new eSankalpMVCDemoEntities();
            var saveBook = new tbl_Book()
            {
                BookName = model.BookName,
                ISBN = model.ISBN,
                Author = model.Author,
            };
            db.tbl_Book.Add(saveBook);
            db.SaveChanges();
            msg = "Book saved successfullly";
            return msg;
        }

        public List<BookModel> GetBookList()
        {
            eSankalpMVCDemoEntities db = new eSankalpMVCDemoEntities();
            List<BookModel> lstBook = new List<BookModel>();

            var bookList = db.tbl_Book.ToList();
            foreach(var book in bookList)
            {
                lstBook.Add(new BookModel
                {
                    BookID=book.BookID,
                    BookName=book.BookName,
                    ISBN=book.ISBN,
                    Author=book.Author,
                });
            }
            return lstBook;
        }

        public BookModel GetBookDetails(long BookID)
        {
            eSankalpMVCDemoEntities db = new eSankalpMVCDemoEntities();
            BookModel bookModel = new BookModel();
            var bookDet = db.tbl_Book.Where(p => p.BookID == BookID).FirstOrDefault();
            
            if(bookDet!=null)
            {
                bookModel.BookName = bookDet.BookName;
                bookModel.ISBN = bookDet.ISBN;
                bookModel.Author = bookDet.Author;
                bookModel.BookID = bookDet.BookID;
            }
            return bookModel;
        }
    }
}