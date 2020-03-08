using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Collections;
using Newtonsoft.Json;

namespace restApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public object GetMovies()
        {
            var movies = System.IO.File.ReadAllText(@"./movies/movies.josn");
            return movies;
        }
        [HttpPost]
        public object Post([FromBody]object value)
        {
            try
            {
                var file = System.IO.File.ReadAllText(@"./movies/movies.josn");

                var json = System.Text.Json.JsonSerializer.Serialize(value);

                dynamic data = JsonConvert.DeserializeObject(json);
                ////movies.Add(data.movie);
                dynamic newMovies = JsonConvert.SerializeObject(data.movies);
                System.IO.File.WriteAllText(@"./movies/movies.josn", newMovies);

                return "ok";
            }
            catch
            {
                return "Not Found";
            }
           
        }

    }
}
