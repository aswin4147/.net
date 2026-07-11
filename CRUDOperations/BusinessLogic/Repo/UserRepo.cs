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
    public class UserRepo : IUserRepo
    {
        private readonly AppDb _db;
        public UserRepo(AppDb db)
        {
            _db = db;
        }
        public async Task<IEnumerable<UserData>> GetUsersAsync()
        {
            var res = await (from x in _db.UserTable select x).ToListAsync();
            return res;
        }

        public async Task AddUserAsync(UserData data)
        {
            _db.UserTable.AddAsync(data);
            await _db.SaveChangesAsync();
        }
    }
}
