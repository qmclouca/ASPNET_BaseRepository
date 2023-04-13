using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaLanches.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        
        [Required(ErrorMessage = "Informe o nome do lanche")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição curta do lanche")]
        [MinLength(20, ErrorMessage = "A descrição de deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição de deve ter no máximo {1} caracteres.")]
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [NotMapped]
        public DateTime DataCriacao { get; set; }
    }
}
