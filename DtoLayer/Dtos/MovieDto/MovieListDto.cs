using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.MovieDto
{
    public class MovieListDto
    {
        public int Rank { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public int Year { get; set; }
        public string ImdbId { get; set; }
    }
}
