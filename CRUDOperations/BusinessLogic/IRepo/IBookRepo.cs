using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IRepo
{
    public interface IBookRepo
    {
        public Task AddBookAsync(BookData book);
        public Task<IEnumerable<BookData>> GetBookDataAsync();
        public Task AddUserAsync(BookLogin user);
        public Task<BookLogin> GetUserAsync(string email, string password);
    }
}
