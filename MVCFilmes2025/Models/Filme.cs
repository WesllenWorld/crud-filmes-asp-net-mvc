using System.ComponentModel.DataAnnotations;

namespace MVCFilmes2025.Models
{
    public class Filme
    {
        public int ID { get; set; }

        [Display(Name = "Título")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Data de lançamento")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Este campo é obrigatório."),
            StringLength(20),
            RegularExpression(@"^[A-ZÀ-Ý]+[a-zA-ZÀ-ÿ\s]*$", ErrorMessage ="Dados inválidos.")]
        
        public string Genero { get; set; } = string.Empty;

        [Display(Name = "Avaliação")]
        [Range(1,10, ErrorMessage ="Somente valores de 1 a 10.")]
        //[Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Avaliacao { get; set; } = 0;
    }
}
