using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDb _db;
        public BookRepo(AppDb db)
        {
            _db = db;
        }

        public async Task AddBookAsync(BookData book)
        {
            await _db.BookTable.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookData>> GetBookDataAsync()
        {
            var res = await _db.BookTable.ToListAsync();
            return res;
        }

        public async Task AddUserAsync(BookLogin user)
        {
            await _db.BookUser.AddAsync(user);
            await _db.SaveChangesAsync();
        }
    }
}
