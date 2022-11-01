using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Categorias")] //desnecessário, redundante
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        [Key] // desnecessário, redundante. Por colocar "id" no nome, o EntityFramework já reconhece
        public int CategoriaId { get; set; }
        
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemURL { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
