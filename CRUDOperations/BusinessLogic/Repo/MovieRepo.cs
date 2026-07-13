using BusinessLogic.IRepo;
using BusinessLogic.Migrations;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repo
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDb _db;

        public MovieRepo(AppDb db)
        {
            _db = db;
        }

        public async Task SaveMovieAsync(MovieDetails details)
        {
            await _db.MovieTable.AddAsync(details);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieDetails>> GetMoviesAsync()
        {
            var res = await (from s in _db.MovieTable select s).ToListAsync();
            return res;
        }

    }
}
