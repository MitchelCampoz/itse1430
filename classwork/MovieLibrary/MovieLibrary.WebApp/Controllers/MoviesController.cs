﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.WebApp.wwwroot
{
    public class MoviesController : Controller
    {
        public MoviesController ( IMovieDatabase database)
        {
            _database = database;
        }

        public IActionResult List ()
        {
            var movies = _database.GetAll().OrderBy(x => x.Title);

            return View(movies);
        }

        private readonly IMovieDatabase _database;
    }
}
