using Ifood.Data;
using Ifood.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ifood.Models
{
    public class RestauranteModel
    {
        [Key]
        public int IdRestaurante { get; set; }
        
        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set;}

        public string? CaminhoImagem { get; set; } = string.Empty;

        [Required]
        [StringLength(55)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(25)]
        public string Categoria { get; set; } = string.Empty;

        [NotMapped]
        [JsonIgnore]
        public List<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();

        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }
        public EnderecoModel? Endereco { get; set; }

        public void addProdutos(DbSet<ProdutoModel> Produtos)
        {

            var produtosList = Produtos.ToList();

            foreach (ProdutoModel produto in produtosList)
            {
                if (produto.IdRestaurante == IdRestaurante)
                {
                    this.Produtos.Add(produto);
                }
            }
        }
        
    }
}
