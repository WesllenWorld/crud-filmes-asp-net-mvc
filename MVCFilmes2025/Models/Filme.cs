using System.ComponentModel.DataAnnotations;

namespace MVCFilmes2025.Models
{
    public class Filme
    {
        public int ID { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Gênero")]
        public string Genero { get; set; } = string.Empty;

        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; } = 0;
    }
}
