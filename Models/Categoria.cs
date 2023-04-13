using System.ComponentModel.DataAnnotations;

namespace VendaLanches.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(3, ErrorMessage = "O nome da categoria deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "O nome da categoria deve ter no máximo {1} caracteres.")]
        [StringLength(200)]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [MinLength(3, ErrorMessage = "A descrição da categoria deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição da categoria deve ter no máximo {1} caracteres.")]
        [StringLength(200)]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }

    }
}
