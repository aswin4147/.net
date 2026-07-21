using Service.IRepo;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repo
{
    public class UserBl : IUser
    {
        private readonly AppDb _db;
        public UserBl(AppDb db)
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
