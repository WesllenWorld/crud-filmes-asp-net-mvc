using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCFilmes2025.Models
{
    public class FilmesViewModel
    {
        public List<Filme> ? Filmes { get; set; }
        public SelectList ? Generos { get; set; }
        public string? Genero { get; set; }
        public string ? Texto { get; set; }
    }
}
