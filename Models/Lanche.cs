using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaLanches.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Display(Name = "Nome do lanche")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        [MinLength(3, ErrorMessage = "O nome do lanche deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "O nome do lanche deve ter no máximo {1} caracteres.")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Display(Name = "Descrição curta")]
        [Required(ErrorMessage = "Informe a descrição curta do lanche")]
        [MinLength(20, ErrorMessage = "A descrição de deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição de deve ter no máximo {1} caracteres.")]
        [StringLength(200)]
        public string DescricaoCurta { get; set; }

        [Display(Name = "Descrição detalhada")]
        [Required(ErrorMessage = "Informe a descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "A descrição detalhada deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição detalhada deve ter no máximo {1} caracteres.")]        
        [StringLength(200)]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço")]
        [Range(0.01, 1000.00, ErrorMessage = "O preço deve estar entre {1} e {2}.")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho da imagem normal.")]
        [StringLength(200)]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho da imagem thumbnail.")]
        [StringLength(200)]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Lanche preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Lanche em estoque?")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }        
    }
}
