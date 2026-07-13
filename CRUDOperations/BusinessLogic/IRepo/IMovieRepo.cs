using BusinessLogic.Migrations;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IRepo
{
    public interface IMovieRepo
    {
        public Task SaveMovieAsync(MovieDetails details);
        public Task<IEnumerable<MovieDetails>> GetMoviesAsync();
    }
}
