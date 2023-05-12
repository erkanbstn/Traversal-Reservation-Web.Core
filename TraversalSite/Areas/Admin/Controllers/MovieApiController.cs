using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DtoLayer.Dtos.MovieDto;
using System.Collections.Generic;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "6f3c06c27fmshbf2db57a98b47f3p1a75a1jsna2114031da3c" },
        { "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jsonContent = JsonConvert.DeserializeObject<List<MovieListDto>>(body);
                return View(jsonContent);
            }

        }
    }
}
