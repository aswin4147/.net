using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IRepo
{
    public interface IUserRepo
    {
        public Task<IEnumerable<UserData>> GetUsersAsync();
        public Task AddUserAsync(UserData data);
    }
}
