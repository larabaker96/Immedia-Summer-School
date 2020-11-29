using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MoviesAPIConsumer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MoviesAPIConsumer.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Movie> movieList = new List<Movie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Movies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<List<Movie>>(apiResponse);
                }
            }
            return View(movieList);
        }

        public ViewResult GetMovie() => View();

        [HttpPost]
        public async Task<IActionResult> GetMovie(int id)
        {
            Movie movie = new Movie();
 
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Movies/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<Movie>(apiResponse);
                }
            }

            if(movie.movieId == id)
            {
                return View(movie);
            }
            else
            {
                ViewBag.Error = "No record found!";
                return View(null);
            }
            
        }

        public ViewResult SearchMovie() => View();

        [HttpPost]
        public async Task<IActionResult> SearchMovie(string query)
        {
            List<Movie> searchResult = new List<Movie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Movies/Search?query=" + query))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    searchResult = JsonConvert.DeserializeObject<List<Movie>>(apiResponse);
                }
            }

            return View(searchResult);
        }

        public ViewResult AddMovie() => View();

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie, List<string> actors)
        {
            Movie receivedMovie = new Movie();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:5001/api/Movies", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedMovie = JsonConvert.DeserializeObject<Movie>(apiResponse);
                }
            }
            return View(receivedMovie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(int MovieId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/Movies/" + MovieId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}