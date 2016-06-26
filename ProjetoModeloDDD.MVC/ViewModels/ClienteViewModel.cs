using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome.")]
        [MaxLength(150, ErrorMessage = "Máximo {0} Caracteres")]
        [MinLength(2, ErrorMessage = "Minimu de {0} Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Sobrenome.")]
        [MaxLength(150, ErrorMessage = "Máximo {0} Caracteres")]
        [MinLength(2, ErrorMessage = "Minimu de {0} Caracteres")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} Caracteres")]
        [EmailAddress(ErrorMessage = "Preencha o Email Válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}