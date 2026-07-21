using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepo
{
    public interface IUser
    {
        public Task<IEnumerable<UserData>> GetUsersAsync();
        public Task AddUserAsync(UserData data);
    }
}
